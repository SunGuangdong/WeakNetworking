using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using YouKe.DBUtility;
using YouKe.Common;

namespace YouKe.DAL
{
    /// <summary>
    /// ���ݷ�����:�û�
    /// </summary>
    public partial class users
    {
        private string databaseprefix; //���ݿ����ǰ׺
        public users(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
        }

        #region ��������================================
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "users");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// ����û����Ƿ����
        /// </summary>
        public bool Exists(string user_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "users");
            strSql.Append(" where user_name=@user_name ");
            SqlParameter[] parameters = {
					new SqlParameter("@user_name", SqlDbType.NVarChar,100)};
            parameters[0].Value = user_name;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// ����˺��Ƿ����
        /// </summary>
        public bool ExistsAcc(string user_account)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "users");
            strSql.Append(" where user_account=@user_account ");
            SqlParameter[] parameters = {
					new SqlParameter("@user_account", SqlDbType.NVarChar,100)};
            parameters[0].Value = user_account;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Model.users model)
        {
            //user_account,user_passworld,reg_time,login_time,user_name,endurance,gold,wing,lv,vip,head,exp

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "users(");
            strSql.Append("user_account,user_passworld,reg_time,login_time,user_name,endurance,gold,wing,lv,vip,head,exp)");
            strSql.Append(" values (");
            strSql.Append("@user_account,@user_passworld,@reg_time,@login_time,@user_name,@endurance,@gold,@wing,@lv,@vip,@head,@exp)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@user_account", SqlDbType.NVarChar,50),
					new SqlParameter("@user_passworld", SqlDbType.NVarChar,50),
					new SqlParameter("@reg_time", SqlDbType.DateTime),
					new SqlParameter("@login_time", SqlDbType.DateTime),
					new SqlParameter("@user_name", SqlDbType.NVarChar,50),
					new SqlParameter("@endurance", SqlDbType.Int,4),
					new SqlParameter("@gold", SqlDbType.Int,4),
					new SqlParameter("@wing", SqlDbType.Int,4),
					new SqlParameter("@lv", SqlDbType.Int,4),
					new SqlParameter("@vip", SqlDbType.Int,4),
					new SqlParameter("@head", SqlDbType.NVarChar,50),
                    new SqlParameter("@exp", SqlDbType.Int,4)};
            parameters[0].Value = model.user_account;
            parameters[1].Value = model.user_passworld;
            parameters[2].Value = model.reg_time;
            parameters[3].Value = model.login_time;
            parameters[4].Value = model.user_name;
            parameters[5].Value = model.endurance;
            parameters[6].Value = model.gold;
            parameters[7].Value = model.wing;
            parameters[8].Value = model.lv;
            parameters[9].Value = model.vip;
            parameters[10].Value = model.head;
            parameters[11].Value = model.exp;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Model.users model)
        {
            //user_account,user_passworld,reg_time,login_time,user_name,endurance,gold,wing,lv,vip,head,exp
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "users set ");
            strSql.Append("user_account=@user_account,");
            strSql.Append("user_passworld=@user_passworld,");
            strSql.Append("reg_time=@reg_time,");
            strSql.Append("login_time=@login_time,");
            strSql.Append("user_name=@user_name,");
            strSql.Append("gold=@gold,");
            strSql.Append("wing=@wing,");
            strSql.Append("lv=@lv,");
            strSql.Append("vip=@vip,");
            strSql.Append("head=@head,");
            strSql.Append("exp=@exp ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@user_account", SqlDbType.NVarChar,50),
					new SqlParameter("@user_passworld", SqlDbType.NVarChar,50),
					new SqlParameter("@reg_time", SqlDbType.DateTime),
					new SqlParameter("@login_time", SqlDbType.DateTime),
					new SqlParameter("@user_name", SqlDbType.NVarChar,50),
					new SqlParameter("@endurance", SqlDbType.Int,4),
					new SqlParameter("@gold", SqlDbType.Int,4),
					new SqlParameter("@wing", SqlDbType.Int,4),
					new SqlParameter("@lv", SqlDbType.Int,4),
					new SqlParameter("@vip", SqlDbType.Int,4),
					new SqlParameter("@head", SqlDbType.NVarChar,50),
                    new SqlParameter("@exp", SqlDbType.Int,4)};
            parameters[0].Value = model.user_account;
            parameters[1].Value = model.user_passworld;
            parameters[2].Value = model.reg_time;
            parameters[3].Value = model.login_time;
            parameters[4].Value = model.user_name;
            parameters[5].Value = model.endurance;
            parameters[6].Value = model.gold;
            parameters[7].Value = model.wing;
            parameters[8].Value = model.lv;
            parameters[9].Value = model.vip;
            parameters[10].Value = model.head;
            parameters[11].Value = model.exp;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int id)
        {
            //��ȡ�û�������
            Model.users model = GetModel(id);
            if (model == null)
            {
                return false;
            }

            List<CommandInfo> sqllist = new List<CommandInfo>();
            
            CommandInfo cmd = new CommandInfo();
            //sqllist.Add(cmd);

           
            //ɾ���û�����
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "users ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;
            cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            int rowsAffected = DbHelperSQL.ExecuteSqlTran(sqllist);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Model.users GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 id,user_account,user_passworld,reg_time,login_time,user_name,endurance,gold,wing,lv,vip,head,exp");
            strSql.Append(" from " + databaseprefix + "users");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// �����˺����뷵��һ��ʵ��
        /// </summary>
        public Model.users GetModel(string user_account, string user_passworld)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 id,user_account,user_passworld,reg_time,login_time,user_name,endurance,gold,wing,lv,vip,head,exp");
            strSql.Append(" from " + databaseprefix + "users");
            strSql.Append(" where user_account=@user_account");

            strSql.Append(" and user_passworld=@user_passworld");

            SqlParameter[] parameters = {
					    new SqlParameter("@user_account", SqlDbType.NVarChar,100),
                        new SqlParameter("@user_passworld", SqlDbType.NVarChar,100)};
            parameters[0].Value = user_account;
            parameters[1].Value = user_passworld;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// �����û�������һ��ʵ��
        /// </summary>
        public Model.users GetModel(string user_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 id,user_account,user_passworld,reg_time,login_time,user_name,endurance,gold,wing,lv,vip,head,exp");
            strSql.Append(" from " + databaseprefix + "users");
            strSql.Append(" where user_name=@user_name");
            SqlParameter[] parameters = {
					new SqlParameter("@user_name", SqlDbType.NVarChar,100)};
            parameters[0].Value = user_name;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,user_account,user_passworld,reg_time,login_time,user_name,endurance,gold,wing,lv,vip,head,exp");
            strSql.Append(" FROM " + databaseprefix + "users ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// ��ò�ѯ��ҳ����
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM " + databaseprefix + "users");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        #endregion

        #region ��չ����================================

        /// <summary>
        /// �޸�һ������
        /// </summary>
        public int UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "users set " + strValue);
            strSql.Append(" where id=" + id);
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Model.users DataRowToModel(DataRow row)
        {
            //user_account,user_passworld,reg_time,login_time,user_name,endurance,gold,wing,lv,vip,head,exp
            Model.users model = new Model.users();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["user_account"] != null)
                {
                    model.user_account = row["user_account"].ToString();
                }
                if (row["user_passworld"] != null)
                {
                    model.user_passworld = row["user_passworld"].ToString();
                }
                if (row["reg_time"] != null && row["reg_time"].ToString() != "")
                {
                    model.reg_time = DateTime.Parse(row["reg_time"].ToString());
                }
                if (row["login_time"] != null && row["login_time"].ToString() != "")
                {
                    model.login_time = DateTime.Parse(row["login_time"].ToString());
                }
                if (row["user_name"] != null)
                {
                    model.user_name = row["user_name"].ToString();
                }
                if (row["endurance"] != null && row["endurance"].ToString() != "")
                {
                    model.endurance = int.Parse(row["endurance"].ToString());
                }
                if (row["gold"] != null && row["gold"].ToString() != "")
                {
                    model.gold = int.Parse(row["gold"].ToString());
                }
                if (row["wing"] != null && row["wing"].ToString() != "")
                {
                    model.wing = int.Parse(row["wing"].ToString());
                }
                if (row["lv"] != null && row["lv"].ToString() != "")
                {
                    model.lv = int.Parse(row["lv"].ToString());
                }
                if (row["vip"] != null && row["vip"].ToString() != "")
                {
                    model.vip = int.Parse(row["vip"].ToString());
                }
                if (row["head"] != null)
                {
                    model.head = row["head"].ToString();
                }
                if (row["exp"] != null && row["exp"].ToString() != "")
                {
                    model.exp = int.Parse(row["exp"].ToString());
                }

                
                
            }
            return model;
        }
        #endregion

    }
}