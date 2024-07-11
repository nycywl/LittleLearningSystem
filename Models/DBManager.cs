using Microsoft.Data.SqlClient;
using System.Data;

namespace LittleLearningSystem.Models
{
    public class DBManager
    {
        string constr = "Server=MSI;Database=StudentCourseDB;Integrated Security=True;Encrypt=False;";

        public DataTable GetDBStudent()
        {
            SqlConnection SqlCon = new SqlConnection(constr);

            string SqlStr = @"
            SELECT  * FROM  [StudentCourseDB].[dbo].[Student]
            ";
            SqlCommand SqlCom = new SqlCommand(SqlStr, SqlCon);
            SqlDataAdapter da = new SqlDataAdapter(SqlCom);
            DataTable dt = new DataTable();

            da.Fill(dt);
            SqlCon.Close();
            return dt;
        }

        public DataTable GetDBCourse(string email)
        {
            DataTable temp = GetDBStudent();

            int studentID = 0;

            foreach (DataRow dr in temp.Rows)
            {
                if (email == dr["Email"].ToString().Trim())
                {
                    studentID = Convert.ToInt32(dr["studentID"].ToString());
                }
            }

            SqlConnection SqlCon = new SqlConnection(constr);

            string SqlStr = @"
            SELECT *
                FROM [StudentCourseDB].[dbo].[Course] As t1
                Left Join [StudentCourseDB].[dbo].[Enroll] As t2
                ON t1.CourseID = t2.CourseID 
                WHERE t2.StudentID = @StudentID
            ";
            SqlCommand SqlCom = new SqlCommand(SqlStr, SqlCon);
            SqlCom.Parameters.AddWithValue("@StudentID", studentID);
            SqlDataAdapter da = new SqlDataAdapter(SqlCom);
            DataTable dt = new DataTable();

            da.Fill(dt);
            SqlCon.Close();
            return dt;
        }

        public DataTable GetDBCourseByID(int id)
        {
            SqlConnection SqlCon = new SqlConnection(constr);

            string SqlStr = @"
            SELECT  * FROM  [StudentCourseDB].[dbo].[Course]
            WHERE  CourseID = @CourseID
            ";
            SqlCommand SqlCom = new SqlCommand(SqlStr, SqlCon);

            SqlCom.Parameters.AddWithValue("@CourseID", id);

            SqlDataAdapter da = new SqlDataAdapter(SqlCom);
            DataTable dt = new DataTable();

            da.Fill(dt);
            SqlCon.Close();
            return dt;
        }

        public void InsertDBCourse(Course course)
        {
            SqlConnection SqlCon = new SqlConnection(constr);

            string SqlStr = @"     
                            INSERT INTO [StudentCourseDB].[dbo].[Course]
                                        ([CourseID]
                                           ,[CourseName]
                                           ,[AmountLimit]
                                           ,[CourseWeek]
                                           ,[CourseTime]
                                        )
                                 VALUES
                                       (@CourseID
                                       ,@CourseName
                                       ,@AmountLimit
                                       ,@CourseWeek
                                       ,@CourseTime 
                                        )       
                            ";
            SqlCommand SqlCom = new SqlCommand(SqlStr, SqlCon);
            SqlCom.Parameters.AddWithValue("@CourseID", course.CourseID);
            SqlCom.Parameters.AddWithValue("@CourseName", course.CourseName);
            SqlCom.Parameters.AddWithValue("@AmountLimit", course.AmountLimit);
            SqlCom.Parameters.AddWithValue("@CourseWeek", course.CourseWeek);
            SqlCom.Parameters.AddWithValue("@CourseTime", course.CourseTime);
            SqlCon.Open();
            SqlCom.ExecuteNonQuery();
            SqlCon.Close();
        }

        public void InsertDBEnroll(string email, int courseID)
        {
            DataTable temp = GetDBStudent();

            int studentID = 0;
            
            foreach (DataRow dr in temp.Rows)
            {
                if (email == dr["Email"].ToString().Trim())
                {
                    studentID = Convert.ToInt32(dr["studentID"].ToString());
                }
            }

            SqlConnection SqlCon = new SqlConnection(constr);

            string SqlStr = @"     
                            INSERT INTO [StudentCourseDB].[dbo].[Enroll]
                                        ([StudentID]
                                           ,[CourseID]
                                        )
                                 VALUES
                                       (@StudentID
                                       ,@CourseID
                                        )       
                            ";
            SqlCommand SqlCom = new SqlCommand(SqlStr, SqlCon);
            SqlCom.Parameters.AddWithValue("@StudentID", studentID);
            SqlCom.Parameters.AddWithValue("@CourseID", courseID);
            SqlCon.Open();
            SqlCom.ExecuteNonQuery();
            SqlCon.Close();
        }

        public void DeleteDBEnroll(string email, int courseID)
        {
            DataTable temp = GetDBStudent();

            int studentID = 0;

            foreach (DataRow dr in temp.Rows)
            {
                if (email == dr["Email"].ToString().Trim())
                {
                    studentID = Convert.ToInt32(dr["studentID"].ToString());
                }
            }

            SqlConnection SqlCon = new SqlConnection(constr);

            string SqlStr = @"     
                            DELETE FROM [StudentCourseDB].[dbo].[Enroll]
                            WHERE StudentID = @StudentID and CourseID = @CourseID     
                            ";
            SqlCommand SqlCom = new SqlCommand(SqlStr, SqlCon);
            SqlCom.Parameters.AddWithValue("@StudentID", studentID);
            SqlCom.Parameters.AddWithValue("@CourseID", courseID);
            SqlCon.Open();
            SqlCom.ExecuteNonQuery();
            SqlCon.Close();
        }

        public void EditDBCourse(Course course)
        {
            SqlConnection SqlCon = new SqlConnection(constr);

            string SqlStr = @"     
                            UPDATE [StudentCourseDB].[dbo].[Course]
                               SET [AmountLimit] = @AmountLimit
                                  ,[CourseWeek] = @CourseWeek
                                  ,[CourseTime] = @CourseTime
                             WHERE CourseID = @CourseID
                            ";
            SqlCommand SqlCom = new SqlCommand(SqlStr, SqlCon);
            SqlCom.Parameters.AddWithValue("@AmountLimit", course.AmountLimit);
            SqlCom.Parameters.AddWithValue("@CourseWeek", course.CourseWeek);
            SqlCom.Parameters.AddWithValue("@CourseTime", course.CourseTime);
            SqlCom.Parameters.AddWithValue("@CourseID", course.CourseID);
            SqlCon.Open();
            SqlCom.ExecuteNonQuery();
            SqlCon.Close();
        }

        public DataTable GetDBEnroll(int CourseID)
        {
            SqlConnection SqlCon = new SqlConnection(constr);

            string SqlStr = @"
            SELECT  * FROM [StudentCourseDB].[dbo].[Student] As t1
		    LEFT JOIN(			
				SELECT  * FROM  [StudentCourseDB].[dbo].[Enroll]
				) AS t2
				ON t1.StudentID = t2. StudentID
				WHERE t2.CourseID = @CourseID
            ";
            SqlCommand SqlCom = new SqlCommand(SqlStr, SqlCon);

            SqlCom.Parameters.AddWithValue("@CourseID", CourseID);

            SqlDataAdapter da = new SqlDataAdapter(SqlCom);
            DataTable dt = new DataTable();

            da.Fill(dt);
            SqlCon.Close();
            return dt;
        }

        public void DeleteDBCourseByID(int id)
        {
            SqlConnection SqlCon = new SqlConnection(constr);

            string SqlStr = @"     
                            DELETE FROM [StudentCourseDB].[dbo].[Course]
                            WHERE CourseID = @CourseID
                            ";
            SqlCommand SqlCom = new SqlCommand(SqlStr, SqlCon);
            SqlCom.Parameters.AddWithValue("@CourseID", id);
            SqlCon.Open();
            SqlCom.ExecuteNonQuery();
            SqlCon.Close();
        }
    }
}
