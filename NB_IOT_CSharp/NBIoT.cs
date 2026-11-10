using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace NB_IOT
{
    public class NBIoT
    {
        [DllImport(@"C:\PAT\Lib\random.dll")]
        public static extern int RAND(int max, int min, int n);

        [DllImport(@"C:\PAT\Lib\NB_IOT.dll")]
        public static extern void aes128_cmac(int keyIndex, int[] msg, int len, int[] MAC);

        [DllImport(@"C:\PAT\Lib\NB_IOT.dll")]
        public static extern void aes128_encrypt(int keyIndex, int[] data, int len, int pad, int[] ans);

        [DllImport(@"C:\PAT\Lib\NB_IOT.dll")]
        public static extern void aes128_cmac2(int[] key, int[] msg, int len, int[] MAC);

        [DllImport(@"C:\PAT\Lib\NB_IOT.dll")]
        public static extern void Compute_SessionKey(int keyIndex, int AppNonce, int NetID, int DevNonce, int pad, int[] ans);

        public static bool CheckMAC(int[] mac1, int[] mac2)
        {
            bool flag = true;
            for (int i = 0; i < 4; i++)
            {
                if (mac1[i] != mac2[i])
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }
        
        public static bool CheckSessionKey(int[] key1, int[] key2)
        {
            bool flag = true;
            for (int i = 0; i < 16; i++)
            {
                if (key1[i] != key2[i])
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }
        
        public static int[] Aes128_cmac(int keyIndex, int[] msg, int len)
        {
            int[] MAC = new int[4];
            aes128_cmac(keyIndex, msg, len, MAC);
            return MAC;
        }
        
        public static int[] Aes128_cmac2(int[] key, int[] msg, int len)
        {
            int[] MAC = new int[4];
            aes128_cmac2(key, msg, len, MAC);
            return MAC;
        }
        
        public static int[] ComputeSessionKey(int keyIndex, int AppNonce, int NetID, int DevNonce, int pad)
        {
            int[] session = new int[16];
            Compute_SessionKey(keyIndex, AppNonce, NetID, DevNonce, pad, session);
            return session;
        }
        
        public static int[] Aes128_encrypt(int keyIndex, int[] data, int len, int pad)
        {
            int[] session = new int[16];
            aes128_encrypt(keyIndex, data, len, pad, session);
            return session;
        }
        
        public static int VerifyConfirm(int confirm, int[] sessionKey)
        {
            // 简单实现，实际应该根据协议规范实现
            return (confirm == 1) ? 1 : 0;
        }
    }
}