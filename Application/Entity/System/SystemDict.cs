using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// ���ߣ�xavier
/// ���ڣ�2019-04-26 09:42:20
/// ������
/// </summary>

namespace Entity.Sys
{
    /// <summary>
    /// ϵͳ�ֵ�
    /// </summary>
    [Serializable]
    public class T_SYSTEM_DICT : BaseEntity
    {
        public static string TABLE_NAME = "t_system_dict";

        private string _code;
        public static string FIELD_CODE = "code";
        /// <summary>
        /// �ֵ����
        /// </summary>
        public string CODE
        {
            get { return _code; }
            set { _code = value; }
        }

        private string _type_code;
        public static string FIELD_TYPE_CODE = "type_code";
        /// <summary>
        /// ���ͱ���
        /// </summary>
        public string TYPE_CODE
        {
            get { return _type_code; }
            set { _type_code = value; }
        }

        private string _text;
        public static string FIELD_TEXT = "text";
        /// <summary>
        /// �ֵ��ı�
        /// </summary>
        public string TEXT
        {
            get { return _text; }
            set { _text = value; }
        }

        private string _isleaf = "0";

        /// <summary>
        /// 1����Ҷ�ӽڵ�
        ///0������Ҷ�ӽڵ㣨Ĭ�ϣ�
        /// </summary>
        public string ISLEAF
        {
            get { return _isleaf; }
            set { _isleaf = value; }
        }

        private int? _sort_number;

        /// <summary>
        /// �����
        /// </summary>
        public int? SORT_NUMBER
        {
            get { return _sort_number; }
            set { _sort_number = value; }
        }

        private string _isuse;

        /// <summary>
        /// �Ƿ�����
        /// 1�����ã�Ĭ�ϣ�
        /// 0��ͣ��
        /// </summary>
        public string ISUSE
        {
            get { return _isuse; }
            set { _isuse = value; }
        }

        private string _isdelete;

        /// <summary>
        /// �Ƿ�ɾ��
        /// 1��ɾ��
        /// 0��δɾ����Ĭ�ϣ�
        /// </summary>
        public string ISDELETE
        {
            get { return _isdelete; }
            set { _isdelete = value; }
        }

        private string _description;

        /// <summary>
        /// ����
        /// </summary>
        public string DESCRIPTION
        {
            get { return _description; }
            set { _description = value; }
        }

        private static string CONSTRAIN_AK_SYSTEM_DICT_CODE = "ak_system_dict_code";

        protected async override Task<Exception> ColumnContrainException(Exception ex)
        {
            System.Reflection.PropertyInfo ColumnNameProperty = ex.GetType().GetProperty("ColumnName");
            if (ColumnNameProperty == null || ColumnNameProperty.GetValue(ex) == null)
            {
                return ex;
            }
            if (ColumnNameProperty.GetValue(ex).Equals(FIELD_CODE))
            {
                return new Exception(await Localization.Localizer.GetValueAsync("���a���ܠ���"));
            }
            if (ColumnNameProperty.GetValue(ex).Equals(FIELD_TEXT))
            {
                return new Exception(await Localization.Localizer.GetValueAsync("���Q���ܠ���"));
            }
            if (ColumnNameProperty.GetValue(ex).Equals(FIELD_TYPE_CODE))
            {
                return new Exception(await Localization.Localizer.GetValueAsync("��Ͳ��ܠ���"));
            }
            return ex;
        }

        protected async override Task<Exception> UniqueContrainException(Exception ex)
        {
            System.Reflection.PropertyInfo contrainNameProperty = ex.GetType().GetProperty("ConstraintName");
            if (contrainNameProperty == null || contrainNameProperty.GetValue(ex) == null)
            {
                return ex;
            }
            if (contrainNameProperty.GetValue(ex).Equals(CONSTRAIN_AK_SYSTEM_DICT_CODE))
            {
                return new Exception(await Localization.Localizer.GetValueAsync("���a���}"));
            }
            return ex;
        }
    }
}
