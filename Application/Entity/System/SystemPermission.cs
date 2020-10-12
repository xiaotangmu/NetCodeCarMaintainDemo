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
    /// ϵͳȨ��
    /// </summary>
    [Serializable]
    public class T_SYSTEM_PERMISSION : BaseEntity
    {
        public static string TABLE_NAME = "t_system_permission";

        private string _code;

        public static readonly string FIELD_CODE = "code";
        /// <summary>
        /// Ȩ�ޱ���
        /// </summary>
        public string CODE
        {
            get { return _code; }
            set { _code = value; }
        }

        private string _name;

        public static readonly string FIELD_NAME = "name";
        /// <summary>
        /// Ȩ������
        /// </summary>
        public string NAME
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _parent_code;

        public static readonly string FIELD_PARENT_CODE = "parent_code";
        /// <summary>
        /// ����Ȩ��ID
        /// </summary>
        public string PARENT_CODE
        {
            get { return _parent_code; }
            set { _parent_code = value; }
        }

        private string _type;

        public static readonly string FIELD_TYPE = "type";
        /// <summary>
        /// Ȩ������
        /// 0������
        ///1��Ȩ��
        /// </summary>
        public string TYPE
        {
            get { return _type; }
            set { _type = value; }
        }

        private int? _sort_num;

        public static readonly string FIELD_SORT_NUM = "sort_num";
        /// <summary>
        /// �����
        /// </summary>
        public int? SORT_NUM
        {
            get { return _sort_num; }
            set { _sort_num = value; }
        }

        private static string CONSTRAIN_AK_SYSTEM_PERMISSION_CODE = "ak_system_permission_code";

        protected async override Task<Exception> ColumnContrainException(Exception ex)
        {
            System.Reflection.PropertyInfo ColumnNameProperty = ex.GetType().GetProperty("ColumnName");
            if (ColumnNameProperty == null || ColumnNameProperty.GetValue(ex) == null)
            {
                return ex;
            }
            if (ColumnNameProperty.GetValue(ex).Equals(FIELD_CODE))
            {
                return new Exception(await Localization.Localizer.GetValueAsync("���޾��a���ܠ���"));
            }
            if (ColumnNameProperty.GetValue(ex).Equals(FIELD_NAME))
            {
                return new Exception(await Localization.Localizer.GetValueAsync("�������Q���ܠ���"));
            }
            if (ColumnNameProperty.GetValue(ex).Equals(FIELD_PARENT_CODE))
            {
                return new Exception(await Localization.Localizer.GetValueAsync("�������޲��ܠ���"));
            }
            if (ColumnNameProperty.GetValue(ex).Equals(FIELD_TYPE))
            {
                return new Exception(await Localization.Localizer.GetValueAsync("������Ͳ��ܠ���"));
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
            if (contrainNameProperty.GetValue(ex).Equals(CONSTRAIN_AK_SYSTEM_PERMISSION_CODE))
            {
                return new Exception(await Localization.Localizer.GetValueAsync("���޾��a���}"));
            }
            return ex;
        }
    }
}
