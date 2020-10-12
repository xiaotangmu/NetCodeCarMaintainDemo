using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

/// <summary>
/// ���ߣ�xavier
/// ���ڣ�2019-04-26 09:42:20
/// ������
/// </summary>

namespace Entity.Workflow
{
    /// <summary>
    /// ҵ������
    /// </summary>
    [Serializable]
    public class WORK_FLOW :BaseEntity
    {
        private string _flow_code;

        /// <summary>
        /// ģ�����
        /// </summary>
        public string FLOW_CODE
        {
          get { return _flow_code;}
          set { _flow_code=value;}
        }

        private string _flow_name;

        /// <summary>
        /// ģ������
        /// </summary>
        public string FLOW_NAME
        {
          get { return _flow_name;}
          set { _flow_name=value;}
        }

        private string _create_user;

        /// <summary>
        /// ������
        /// </summary>
        public string CREATE_USER
        {
            get { return _create_user; }
            set { _create_user = value; }
        }

        private string _modify_user;

        /// <summary>
        /// �޸���
        /// </summary>
        public string MODIFY_USER
        {
            get { return _modify_user; }
            set { _modify_user = value; }
        }

        private string _remark1;

        /// <summary>
        /// ��ע1
        /// </summary>
        public string REMARK1
        {
            get { return _remark1; }
            set { _remark1 = value; }
        }

        private string _remark2;

        /// <summary>
        /// ��ע2
        /// </summary>
        public string REMARK2
        {
            get { return _remark2; }
            set { _remark2 = value; }
        }
    }
}
