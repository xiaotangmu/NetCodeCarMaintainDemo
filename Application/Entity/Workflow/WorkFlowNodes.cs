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
    /// ���̽ڵ�
    /// </summary>
    [Serializable]
    public class WORK_FLOW_NODES :BaseEntity
    {
        private string _flow_id;

        /// <summary>
        /// ģ��ʵ��ID
        /// </summary>
        public string FLOW_ID
        {
          get { return _flow_id;}
          set { _flow_id=value;}
        }

        private string _node_code;

        /// <summary>
        /// �ڵ����
        /// </summary>
        public string NODE_CODE
        {
          get { return _node_code;}
          set { _node_code=value;}
        }

        private string _node_name;

        /// <summary>
        /// �ڵ�����
        /// </summary>
        public string NODE_NAME
        {
          get { return _node_name; }
          set { _node_name = value;}
        }

        private string _role_id;

        /// <summary>
        /// ��ɫID���ĸ���ɫ�Դ˽ڵ��������
        /// </summary>
        public string ROLE_ID
        {
          get { return _role_id;}
          set { _role_id=value;}
        }

        private int _node_index;

        /// <summary>
        /// �ڵ���ţ�Ĭ��Ϊ0
        /// </summary>
        public int NODE_INDEX
        {
          get { return _node_index;}
          set { _node_index=value;}
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
