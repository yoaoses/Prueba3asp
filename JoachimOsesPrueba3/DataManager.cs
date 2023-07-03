using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace JoachimOsesPrueba3
{
    internal class DataManager
    {
        public List<Student> getAll(string tableName)
        {
            List<Student> obtainedData = new List<Student>();
            Connector localConn = new Connector();
            try
            {
                localConn.openConn();
                string query = "select * from "+tableName;
                SqlCommand comm = new SqlCommand(query, localConn.conn);
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    Student dataHolder = new Student(
                        Convert.ToInt32(reader[0]),
                        Convert.ToString(reader[1]),
                        Convert.ToString(reader[2])
                    );
                    obtainedData.Add(dataHolder);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                localConn.closeConn();
            }
            return obtainedData;
        }
        public string updateStudent(Student student)
        {
            Connector localConn = new Connector();
            try
            {
                localConn.openConn();
                string query = "UPDATE alumno SET rut = @rut, nombre = @nombre WHERE id = @id";
                SqlCommand comm = new SqlCommand(query, localConn.conn);
                comm.Parameters.AddWithValue("@rut", student.Rut);
                comm.Parameters.AddWithValue("@nombre", student.Nombre);
                comm.Parameters.AddWithValue("@id", student.Id);
                int rowsAffected = comm.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return "success";
                }
                else
                {
                    return "No se encontró ningún registro para actualizar.";
                }
            }
            catch (Exception e)
            {
                return "Error al realizar la actualización: " + e.Message;
            }
            finally
            {
                localConn.closeConn();
            }
        }

        public List<Asignatura> getAllSubjects(string tableName)
        {
            List<Asignatura> obtainedData = new List<Asignatura>();
            Connector localConn = new Connector();
            try
            {
                localConn.openConn();
                string query = "SELECT * FROM " + tableName;
                SqlCommand comm = new SqlCommand(query, localConn.conn);
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    Asignatura dataHolder = new Asignatura(
                        Convert.ToInt32(reader["id"]),
                        Convert.ToString(reader["codigo"]),
                        Convert.ToString(reader["nombre"]),
                        reader["horas"] != DBNull.Value ? Convert.ToInt32(reader["horas"]) : 0,
                        reader["semestre"] != DBNull.Value ? Convert.ToInt32(reader["semestre"]) : 0
                    );
                    obtainedData.Add(dataHolder);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                localConn.closeConn();
            }
            return obtainedData;
        }

        public string UpdateAsignatura(Asignatura asignatura)
        {
            Connector localConn = new Connector();
            try
            {
                localConn.openConn();
                string query = "UPDATE asignatura SET codigo = @codigo, nombre = @nombre, horas = @horas, semestre = @semestre WHERE id = @id";
                SqlCommand comm = new SqlCommand(query, localConn.conn);
                comm.Parameters.AddWithValue("@codigo", asignatura.Codigo);
                comm.Parameters.AddWithValue("@nombre", asignatura.Nombre);
                comm.Parameters.AddWithValue("@horas", asignatura.Horas);
                comm.Parameters.AddWithValue("@semestre", asignatura.Semestre);
                comm.Parameters.AddWithValue("@id", asignatura.Id);
                int rowsAffected = comm.ExecuteNonQuery();
                return "success";
            }
            catch (Exception e)
            {
                
                return e.Message;
            }
            finally
            {
                localConn.closeConn();
            }
        }

        public string insertIntoTable(String tableName, String[] values)
        {
            if (values == null || values.Length == 0)
            {
                return "Error: No se proporcionaron valores para insertar.";
            }

            /*StringBuilder clase en C# que se utiliza para manipular y construir cadenas de manera eficiente.*/
            StringBuilder queryBuilder = new StringBuilder();
            queryBuilder.Append($"INSERT INTO {tableName} VALUES (");

            for (int i = 0; i < values.Length; i++)
            {
                queryBuilder.Append($"@value{i + 1}");

                if (i < values.Length - 1)
                {
                    queryBuilder.Append(", ");
                }
            }

            queryBuilder.Append(")");

            string query = queryBuilder.ToString();

            Connector localConn = new Connector();
            try
            {
                localConn.openConn();

                using (SqlCommand command = new SqlCommand(query, localConn.conn))
                {
                    for (int i = 0; i < values.Length; i++)
                    {
                        command.Parameters.AddWithValue($"@value{i + 1}", values[i]);
                    }

                    command.ExecuteNonQuery();
                }

                return "success"; // Mensaje de éxito
            }
            catch (Exception ex)
            {
                return $"error: {ex.Message}"; // Mensaje de error 
            }
            finally
            {
                localConn.closeConn();
            }
        }

        public string deleteThisone(String table,int id)
        {
            Connector localConn = new Connector();
            try
            {
                localConn.openConn();
                string query = "DELETE FROM "+table+" WHERE id = @id";
                SqlCommand comm = new SqlCommand(query, localConn.conn);
                comm.Parameters.AddWithValue("@id", id);
                int rowsAffected = comm.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return "success";
                }
                else
                {
                    return "No se encontró ningún registro para eliminar.";
                }
            }
            catch (Exception e)
            {
                return "Error al realizar la eliminación: " + e.Message;
            }
            finally
            {
                localConn.closeConn();
            }
        }

        public List<Inscripcion> SelectAllInscriptions()
        {
            List<Inscripcion> inscripciones = new List<Inscripcion>();
            Connector localConn = new Connector();
            try
            {
                localConn.openConn();
                /*
                string query = @"SELECT alumno.nombre AS studentName, asignatura.nombre AS subjectName, asignatura.semestre, 
                 inscripcion.fecha, inscripcion.id, inscripcion.rut, inscripcion.codigo
                 FROM inscripcion
                 INNER JOIN asignatura ON inscripcion.codigo = asignatura.codigo
                 INNER JOIN alumno ON inscripcion.rut = alumno.rut";
                */
                string query = @"Select * from VistaInscripcion";
                SqlCommand comm = new SqlCommand(query, localConn.conn);
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    string studentName = Convert.ToString(reader["studentName"]);
                    string subjectName = Convert.ToString(reader["subjectName"]);
                    int semestre = Convert.ToInt32(reader["semestre"]);
                    DateTime fecha = Convert.ToDateTime(reader["fecha"]);
                    int id = Convert.ToInt32(reader["id"]);
                    string rut = Convert.ToString(reader["rut"]);
                    string codigo = Convert.ToString(reader["codigo"]);

                    Inscripcion inscripcion = new Inscripcion(id, rut, codigo, fecha);
                    inscripcion.semestre = semestre;
                    inscripcion.studentName = studentName;
                    inscripcion.subjectName = subjectName;
                    inscripciones.Add(inscripcion);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                localConn.closeConn();
            }

            return inscripciones;
        }

        public List<Inscripcion> SelectAllStudentRelated(string rutAlumno)
        {
            List<Inscripcion> inscripciones = new List<Inscripcion>();
            Connector localConn = new Connector();
            try
            {
                localConn.openConn();
                string query = @"SELECT alumno.nombre AS studentName, asignatura.nombre AS subjectName, asignatura.semestre, 
                         inscripcion.fecha, inscripcion.id, inscripcion.rut, inscripcion.codigo
                         FROM inscripcion
                         INNER JOIN asignatura ON inscripcion.codigo = asignatura.codigo
                         INNER JOIN alumno ON inscripcion.rut = alumno.rut
                         WHERE alumno.rut = @rutAlumno";
                SqlCommand comm = new SqlCommand(query, localConn.conn);
                comm.Parameters.AddWithValue("@rutAlumno", rutAlumno);
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    string studentName = Convert.ToString(reader["studentName"]);
                    string subjectName = Convert.ToString(reader["subjectName"]);
                    int semestre = Convert.ToInt32(reader["semestre"]);
                    DateTime fecha = Convert.ToDateTime(reader["fecha"]);
                    int id = Convert.ToInt32(reader["id"]);
                    string rut = Convert.ToString(reader["rut"]);
                    string codigo = Convert.ToString(reader["codigo"]);

                    Inscripcion inscripcion = new Inscripcion(id, rut, codigo, fecha);
                    inscripcion.semestre = semestre;
                    inscripcion.studentName = studentName;
                    inscripcion.subjectName = subjectName;
                    inscripciones.Add(inscripcion);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                localConn.closeConn();
            }

            return inscripciones;
        }

        public List<Inscripcion> SelectAllSubjectRelated(string codigoAsignatura)
        {
            List<Inscripcion> inscripciones = new List<Inscripcion>();
            Connector localConn = new Connector();
            try
            {
                localConn.openConn();
                string query = @"SELECT alumno.nombre AS studentName, asignatura.nombre AS subjectName, asignatura.semestre, 
                         inscripcion.fecha, inscripcion.id, inscripcion.rut, inscripcion.codigo
                         FROM inscripcion
                         INNER JOIN asignatura ON inscripcion.codigo = asignatura.codigo
                         INNER JOIN alumno ON inscripcion.rut = alumno.rut
                         WHERE asignatura.codigo = @codigoAsignatura";
                SqlCommand comm = new SqlCommand(query, localConn.conn);
                comm.Parameters.AddWithValue("@codigoAsignatura", codigoAsignatura);
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    string studentName = Convert.ToString(reader["studentName"]);
                    string subjectName = Convert.ToString(reader["subjectName"]);
                    int semestre = Convert.ToInt32(reader["semestre"]);
                    DateTime fecha = Convert.ToDateTime(reader["fecha"]);
                    int id = Convert.ToInt32(reader["id"]);
                    string rut = Convert.ToString(reader["rut"]);
                    string codigo = Convert.ToString(reader["codigo"]);

                    Inscripcion inscripcion = new Inscripcion(id, rut, codigo, fecha);
                    inscripcion.semestre = semestre;
                    inscripcion.studentName = studentName;
                    inscripcion.subjectName = subjectName;
                    inscripciones.Add(inscripcion);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                localConn.closeConn();
            }

            return inscripciones;
        }

    }
}