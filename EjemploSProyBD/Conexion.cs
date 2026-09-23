using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace EjemploSProyBD
{
    public class Conexion
    {
        // Nota: Asegúrate de que no necesites agregar "Uid=root;Pwd=tu_contraseña;" a esta cadena.
        private static string cadenaConexion = "Server=localhost; Database=productosdb; Uid=root; Pwd=jacu200616;";

        public static MySqlConnection ObtenerConexion()
        {
            try
            {
                MySqlConnection conexion = new MySqlConnection(cadenaConexion);
                conexion.Open(); // 1. Faltaba abrir la conexión
                return conexion; // 2. Faltaba retornar el objeto de conexión
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al conectar: " + ex.Message);
                return null;
            } // fin del try
        } // fin del método ObtenerConexion

        public static List<Producto> GetProductos(string filtro)
        {
            List<Producto> listaProductos = new List<Producto>();
            string sqlQuery = "SELECT id, nombre, precio, cantidad, imagen FROM productos";

            if (!string.IsNullOrEmpty(filtro))
            {
                // 3. Se corrigió el espaciado antes del WHERE y la redundancia del operador +=
                sqlQuery += " WHERE id LIKE @filtro OR nombre LIKE @filtro OR precio LIKE @filtro OR cantidad LIKE @filtro";
            }

            using (MySqlConnection conexion = ObtenerConexion())
            {
                // 4. Se corrigió la lógica invertida (debe ser == null)
                if (conexion == null) return listaProductos;

                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, conexion))
                {
                    if (!string.IsNullOrEmpty(filtro))
                    {
                        cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");
                    }

                    using (MySqlDataReader mReader = cmd.ExecuteReader())
                    {
                        while (mReader.Read())
                        {
                            Producto regProducto = new Producto();

                            regProducto.Id = Convert.ToInt32(mReader["id"]);
                            // 5. Se agregó .ToString() para castear correctamente el nombre
                            regProducto.Nombre = mReader["nombre"].ToString();
                            regProducto.Precio = Convert.ToDecimal(mReader["precio"]);

                            // 6. Faltaba asignar la cantidad que traes en el SELECT
                            regProducto.Cantidad = Convert.ToInt32(mReader["cantidad"]);

                            regProducto.Imagen = mReader["imagen"] != DBNull.Value ? (byte[])mReader["imagen"] : null;

                            // agregamos el objeto a la lista genérica
                            listaProductos.Add(regProducto);
                        }
                    } // fin de MySqlDataReader mReader

                } // fin de MySqlCommand

                return listaProductos;
            }

        }

        public static bool InsertSeguro(string tbName, Dictionary<string, object> data)
        {
            var columns = string.Join(", ", data.Keys);
            var placeholders = "@" + string.Join(", @", data.Keys);
            string sql = $"INSERT INTO {tbName} ({columns}) VALUES ({placeholders})";

            try
            {
                using (MySqlConnection conexion = ObtenerConexion())
                {
                    if (conexion == null) return false;

                    using (MySqlCommand stmt = new MySqlCommand(sql, conexion))
                    {
                        foreach (var kvp in data)
                        {
                            stmt.Parameters.AddWithValue("@" + kvp.Key, kvp.Value ?? DBNull.Value);
                        }
                        stmt.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error en INSERT: " + ex.Message);
                return false;
            }
        }

        public static bool UpdateSeguro(string tbName, Dictionary<string, object> data, int id)
        {
            // Construye la parte "nombre = @nombre, precio = @precio" dinámicamente
            List<string> updates = new List<string>();
            foreach (var key in data.Keys)
            {
                updates.Add($"{key} = @{key}");
            }
            string setClause = string.Join(", ", updates);
            string sql = $"UPDATE {tbName} SET {setClause} WHERE id = @id";

            try
            {
                using (MySqlConnection conexion = ObtenerConexion())
                {
                    if (conexion == null) return false;
                    using (MySqlCommand stmt = new MySqlCommand(sql, conexion))
                    {
                        foreach (var kvp in data)
                        {
                            stmt.Parameters.AddWithValue("@" + kvp.Key, kvp.Value ?? DBNull.Value);
                        }
                        stmt.Parameters.AddWithValue("@id", id);

                        stmt.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error en UPDATE: " + ex.Message);
                return false;
            }
        }

        public static bool Delete(string tbName, int id)
        {
            string sql = $"DELETE FROM {tbName} WHERE id = @id";
            try
            {
                using (MySqlConnection conexion = ObtenerConexion())
                {
                    if (conexion == null) return false;
                    using (MySqlCommand stmt = new MySqlCommand(sql, conexion))
                    {
                        stmt.Parameters.AddWithValue("@id", id);
                        stmt.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error en DELETE: " + ex.Message);
                return false;
            }
        }

    }
}