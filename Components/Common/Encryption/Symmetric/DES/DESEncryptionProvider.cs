using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Common.Encryption.Core;
using Common.Encryption.Core.Internals;
using Common.Encryption.Core.Internals.Extensions;

// ReSharper disable once CheckNamespace
namespace Common.Encryption
{
    /// <summary>
    /// DES 加密提供程序
    /// </summary>
    public sealed class DESEncryptionProvider:SymmetricEncryptionBase
    {
        /// <summary>
        /// 初始化一个<see cref="DESEncryptionProvider"/>类型的实例
        /// </summary>
        private DESEncryptionProvider() { }

        /// <summary>
        /// 创建 DES 密钥
        /// </summary>
        /// <returns></returns>
        public static DESKey CreateKey()
        {
            return new DESKey()
            {
                Key = RandomStringGenerator.Generate(),
                IV = RandomStringGenerator.Generate(),
            };
        }

        #region DES byte[]

        /// <summary>
        /// 加密 byte[]
        /// </summary>
        /// <param name="value">待加密的值</param>
        /// <param name="key">密钥</param>
        /// <param name="iv">加密偏移量</param>
        /// <param name="salt">加盐</param>
        /// <param name="encoding">编码类型，默认为<see cref="Encoding.UTF8"/></param>
        /// <returns></returns>
        public static byte[] Encrypt(byte[] value, string key, string iv = null, string salt = null,Encoding encoding = null)
        {
            if (value==null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }

            var result = EncryptCore<AesCryptoServiceProvider>(value,
                ComputeRealValueFunc()(key)(salt)(encoding)(64),
                ComputeRealValueFunc()(iv)(salt)(encoding)(64));

            return result;
        }

        /// <summary>
        /// 加密 byte[]
        /// </summary>
        /// <param name="value">待加密的值</param>
        /// <param name="key">DES 密钥对象</param>
        /// <param name="encoding">编码类型，默认为<see cref="Encoding.UTF8"/></param>
        /// <returns></returns>
        public static byte[] Encrypt(byte[] value, DESKey key, Encoding encoding = null)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            return Encrypt(value, key.Key, key.IV, encoding: encoding);
        }

        /// <summary>
        /// 解密 byte[]
        /// </summary>
        /// <param name="value">待解密的值</param>
        /// <param name="key">密钥</param>
        /// <param name="iv">加密偏移量</param>
        /// <param name="salt">加盐</param>
        /// <param name="encoding">编码类型，默认为<see cref="Encoding.UTF8"/></param>
        /// <returns></returns>
        public static byte[] Decrypt(byte[] value, string key, string iv = null, string salt = null, Encoding encoding = null)
        {
            if (value==null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }

            var result = DecryptCore<DESCryptoServiceProvider>(value,
                ComputeRealValueFunc()(key)(salt)(encoding)(64),
                ComputeRealValueFunc()(iv)(salt)(encoding)(64));

            return result;
        }

        /// <summary>
        /// 解密 byte[]
        /// </summary>
        /// <param name="value">待加密的值</param>
        /// <param name="key">DES 密钥对象</param>
        /// <param name="encoding">编码类型，默认为<see cref="Encoding.UTF8"/></param>
        /// <returns></returns>
        public static byte[] Decrypt(byte[] value, DESKey key, Encoding encoding = null)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            return Decrypt(value, key.Key, key.IV, encoding: encoding);
        }

        #endregion



        #region DES string

        /// <summary>
        /// 加密 string
        /// </summary>
        /// <param name="value">待加密的值</param>
        /// <param name="key">密钥</param>
        /// <param name="iv">加密偏移量</param>
        /// <param name="salt">加盐</param>
        /// <param name="outType">输出类型，默认为<see cref="OutType.Base64"/></param>
        /// <param name="encoding">编码类型，默认为<see cref="Encoding.UTF8"/></param>
        /// <returns></returns>
        public static string Encrypt(string value, string key, string iv = null, string salt = null,
            OutType outType = OutType.Base64,
            Encoding encoding = null)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }

            var result = EncryptCore<AesCryptoServiceProvider>(encoding.GetBytes(value),
                ComputeRealValueFunc()(key)(salt)(encoding)(64),
                ComputeRealValueFunc()(iv)(salt)(encoding)(64));

            if (outType == OutType.Base64)
            {
                return Convert.ToBase64String(result);
            }

            return result.ToHexString();
        }

        /// <summary>
        /// 加密 string
        /// </summary>
        /// <param name="value">待加密的值</param>
        /// <param name="key">DES 密钥对象</param>
        /// <param name="outType">输出类型，默认为<see cref="OutType.Base64"/></param>
        /// <param name="encoding">编码类型，默认为<see cref="Encoding.UTF8"/></param>
        /// <returns></returns>
        public static string Encrypt(string value, DESKey key, OutType outType = OutType.Base64,
            Encoding encoding = null)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            return Encrypt(value, key.Key, key.IV, outType: outType, encoding: encoding);
        }

        /// <summary>
        /// 解密 string
        /// </summary>
        /// <param name="value">待解密的值</param>
        /// <param name="key">密钥</param>
        /// <param name="iv">加密偏移量</param>
        /// <param name="salt">加盐</param>
        /// <param name="outType">输出类型，默认为<see cref="OutType.Base64"/></param>
        /// <param name="encoding">编码类型，默认为<see cref="Encoding.UTF8"/></param>
        /// <returns></returns>
        public static string Decrypt(string value, string key, string iv = null, string salt = null,
            OutType outType = OutType.Base64,
            Encoding encoding = null)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }

            var result = DecryptCore<DESCryptoServiceProvider>(value.GetEncryptBytes(outType),
                ComputeRealValueFunc()(key)(salt)(encoding)(64),
                ComputeRealValueFunc()(iv)(salt)(encoding)(64));

            if (outType == OutType.Base64)
            {
                return Convert.ToBase64String(result);
            }

            return result.ToHexString();
        }

        /// <summary>
        /// 解密 string
        /// </summary>
        /// <param name="value">待加密的值</param>
        /// <param name="key">DES 密钥对象</param>
        /// <param name="outType">输出类型，默认为<see cref="OutType.Base64"/></param>
        /// <param name="encoding">编码类型，默认为<see cref="Encoding.UTF8"/></param>
        /// <returns></returns>
        public static string Decrypt(string value, DESKey key, OutType outType = OutType.Base64,
            Encoding encoding = null)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            return Decrypt(value, key.Key, key.IV, outType: outType, encoding: encoding);
        }

        #endregion
    }
}
