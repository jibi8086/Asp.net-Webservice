     public string InsertData(int id,string name,string dept)
        {
            int value=0;
            string constring = ConfigurationManager.ConnectionStrings["Constring"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("USPSampleData", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter parm = new SqlParameter("@flag", SqlDbType.Int);
                    parm.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(parm);
                    cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
                    cmd.Parameters.Add("@dept", SqlDbType.VarChar).Value = dept;
                    con.Open();
                    value = cmd.ExecuteNonQuery();
                    con.Close();                  
                }
            }
            return value.ToString();
        }
        
        
        /// asp.net
        
        
          insertdata.Sample obj = new insertdata.Sample();
            string returnData;
            returnData=obj.InsertData(Convert.ToInt32(TextBox1.Text), TextBox2.Text, TextBox3.Text);
