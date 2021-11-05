﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;


namespace Assignment_2
{
    class Datahandler
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["BCDB"].ConnectionString);

        public byte[] Picture_Loader(int id)
        {

            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand($"Select Images from Student where [Student Number] = {id}", connection);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    byte[] img = (byte[])(reader[0]);
                    return img;
                }



            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            finally
            {
                connection.Close();
            }

            return null;
        }

        public DataTable ReadView()
        {

            DataTable table = new DataTable();

            try
            {
                connection.Open();

                SqlDataAdapter ad = new SqlDataAdapter("Select * from StudentModules", connection);

                ad.Fill(table);

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            finally
            {
                connection.Close();
            }


            return table;
        }


        public void InsertStudent(Student student)
        {

            string query = $@"insert into Student values({student.Id},'{student.Name}','{student.Surname}',@Pic,'{student.Dob}','{student.Gender}','{student.PhoneNo.ToString()}','{student.Address}',{student.Code});";

            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@Pic", student.Image);
                command.ExecuteNonQuery();
                MessageBox.Show("A new student was added");
            }
            catch (Exception er)
            {
                throw er;
            }
            finally
            {
                connection.Close();
            }

        }


        public void InsertModule(Module module)
        {
            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand("INS_Module", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ModuleCode", module.Code);
                command.Parameters.AddWithValue("@Name", module.Name);
                command.Parameters.AddWithValue("@Description", module.Description);
                command.Parameters.AddWithValue("@Resources", module.Resources);
                command.ExecuteNonQuery();
                MessageBox.Show("A new Module was added");
            }
            catch (Exception er)
            {
                throw er;
            }
            finally
            {
                connection.Close();
            }

        }


    }
}