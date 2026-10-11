using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Demo
{
    internal static class SoundManager
    {
        [DllImport("winmm.dll", CharSet = CharSet.Auto)]
        private static extern int mciSendString(string command, StringBuilder buffer, int bufferSize, IntPtr hwndCallback);

        private static bool isMuted = false;
        private static string bgmPath = "";
        private static string flipPath = "";
        private static string correctPath = "";
        private static string wrongPath = "";
        private static int sfxCounter = 0;

        public static bool IsMuted
        {
            get { return isMuted; }
            set
            {
                isMuted = value;
                if (isMuted)
                {
                    PauseBgm();
                }
                else
                {
                    ResumeBgm();
                }
            }
        }

        public static void Initialize()
        {
            try
            {
                string resFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources");
                if (!Directory.Exists(resFolder))
                {
                    // Fallback nếu chạy trong Visual Studio hoặc đường dẫn khác
                    resFolder = Path.Combine(ApplicationStartupFolder(), "Resources");
                }

                bgmPath = Path.Combine(resFolder, "music background.mp3");
                flipPath = Path.Combine(resFolder, "lat.mp3");
                correctPath = Path.Combine(resFolder, "correct.mp3");
                wrongPath = Path.Combine(resFolder, "wrong.mp3");
            }
            catch (Exception)
            {
                // Bẫy lỗi để không crash ứng dụng nếu có lỗi đường dẫn
            }
        }

        private static string ApplicationStartupFolder()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        public static void PlayBgm()
        {
            if (isMuted) return;
            try
            {
                if (File.Exists(bgmPath))
                {
                    mciSendString("close bgm", null, 0, IntPtr.Zero);
                    mciSendString(string.Format("open \"{0}\" type mpegvideo alias bgm", bgmPath), null, 0, IntPtr.Zero);
                    mciSendString("play bgm repeat", null, 0, IntPtr.Zero);
                }
            }
            catch (Exception)
            {
            }
        }

        public static void PauseBgm()
        {
            try
            {
                mciSendString("pause bgm", null, 0, IntPtr.Zero);
            }
            catch (Exception)
            {
            }
        }

        public static void ResumeBgm()
        {
            if (isMuted) return;
            try
            {
                mciSendString("resume bgm", null, 0, IntPtr.Zero);
            }
            catch (Exception)
            {
            }
        }

        public static void StopBgm()
        {
            try
            {
                mciSendString("stop bgm", null, 0, IntPtr.Zero);
                mciSendString("close bgm", null, 0, IntPtr.Zero);
            }
            catch (Exception)
            {
            }
        }

        public static void PlayFlip()
        {
            PlaySfx(flipPath);
        }

        public static void PlayCorrect()
        {
            PlaySfx(correctPath);
        }

        public static void PlayWrong()
        {
            PlaySfx(wrongPath);
        }

        private static void PlaySfx(string path)
        {
            if (isMuted) return;
            try
            {
                if (File.Exists(path))
                {
                    sfxCounter++;
                    if (sfxCounter > 100) sfxCounter = 1;
                    string alias = "sfx_" + sfxCounter;

                    mciSendString(string.Format("close {0}", alias), null, 0, IntPtr.Zero);
                    mciSendString(string.Format("open \"{0}\" type mpegvideo alias {1}", path, alias), null, 0, IntPtr.Zero);
                    mciSendString(string.Format("play {0} from 0", alias), null, 0, IntPtr.Zero);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
