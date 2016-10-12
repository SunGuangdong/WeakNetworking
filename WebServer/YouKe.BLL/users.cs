using System;
using System.Data;
using System.Collections.Generic;


namespace YouKe.BLL
{
    /// <summary>
    /// �û���Ϣ
    /// </summary>
    public partial class users
    {
        
        private readonly DAL.users dal;
        public users()
        {
            dal = new DAL.users("mb_");
        }

        #region ��������===================================
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// ����˺��Ƿ����
        /// </summary>
        public bool ExistsAcc(string user_account)
        {
            return dal.ExistsAcc(user_account);
        }

        /// <summary>
        /// ����û����Ƿ����
        /// </summary>
        public bool Exists(string user_name)
        {
            return dal.Exists(user_name);
        }

        

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Model.users model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Model.users model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Model.users GetModel(uint id)
        {
            return dal.GetModel((int)id);
        }
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Model.users GetModel(int id)
        {
            return dal.GetModel(id);
        }

        

        /// <summary>
        /// �����û�������һ��ʵ��
        /// </summary>
        public Model.users GetModel(string user_name)
        {
            return dal.GetModel(user_name);
        }

        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// ��ò�ѯ��ҳ����
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }
        #endregion

        #region ��չ����===================================
        /// <summary>
        /// �޸�һ������
        /// </summary>
        public int UpdateField(int id, string strValue)
        {
            return dal.UpdateField(id, strValue);
        }

        /// <summary>
        /// �����û��������ȡModel
        /// </summary>
        /// <param name="acc"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public Model.users GetModel(string acc, string pass)
        {
            return dal.GetModel(acc, pass);
        }
        #endregion

    }
}