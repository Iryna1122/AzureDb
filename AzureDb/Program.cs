using Npgsql;
using System;
using System.Data;

////var connStr =new NpgsqlConnectionStringBuilder("Server=c.testdboliinyk.postgres.database.azure.com;Database=citus;Port=5432;User Id=citus;Password=Kashot2016;Ssl Mode=Require;Pooling = true; Minimum Pool Size=0; Maximum Pool Size =50;");
////DataTable dataTable = new DataTable();
////connStr.TrustServerCertificate= true;

////using (var connection = new NpgsqlConnection(connStr.ToString()))
////{
////    //1 CREATE TABLE
////    connection.Open();

////    //NpgsqlCommand npgsqlCommand = new NpgsqlCommand("create table student (id serial primary key , firstname varchar(30),age int not null )", connection);


////    //npgsqlCommand.ExecuteNonQuery();

//2 INSERT
//NpgsqlCommand npgsql = new NpgsqlCommand("insert into student (firstname,age) values(@firstname,@age) ", connection);

//npgsql.Parameters.AddWithValue("firstname", "Inna");
//npgsql.Parameters.AddWithValue("age", 35);
//int count = npgsql.ExecuteNonQuery();

//Console.WriteLine(count);
//Console.WriteLine("Done");



//4 UPDATE
//NpgsqlCommand cmd2 = new NpgsqlCommand("update student set firstname=@firstname where id=@id", connection);
//cmd2.Parameters.AddWithValue("id", 3);
//cmd2.Parameters.AddWithValue("firstname", "Artemon");

//cmd2.ExecuteNonQuery();


////3 SELECT

//NpgsqlCommand cmd = new NpgsqlCommand("select * from student", connection);

//var result = cmd.ExecuteReader();

//while (result.Read())
//{
//    Console.WriteLine(string.Format("id:{0} - firstname:{1} - age:{2}", result.GetInt32(0).ToString(), result.GetString(1), result.GetInt32(2).ToString()));
//}

//result.Close();


//5 Від'єднаний режим



//    NpgsqlCommand cmd = new NpgsqlCommand("select * from student", connection);

//    NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(cmd);

//    dataAdapter.Fill(dataTable);

//}

//if(dataTable.Rows.Count!=0)
//{
//    for (int i = 0; i < dataTable.Rows.Count; i++)
//    {
//        for (int j = 0; j < dataTable.Columns.Count; j++)
//        {
//            Console.Write(dataTable.Rows[i][j] +"  ");
//        }
//        Console.WriteLine();
//    }
//}

//HOMEWORK DB

var connStr = new NpgsqlConnectionStringBuilder("Server=c.testdboliinyk.postgres.database.azure.com;Database=citus;Port=5432;User Id=citus;Password=Kashot2016;Ssl Mode=Require;Pooling = true; Minimum Pool Size=0; Maximum Pool Size =50;");
DataTable dataTable = new DataTable();
connStr.TrustServerCertificate = true;

using (var connection = new NpgsqlConnection(connStr.ToString()))
{
    //1 CREATE TABLE
    connection.Open();

    //////table1
    ////NpgsqlCommand command1 = new NpgsqlCommand(
    ///"CREATE TABLE address ( id serial PRIMARY KEY,country VARCHAR (20) ,city VARCHAR (20) , street VARCHAR (20) )", connection);
    ////command1.ExecuteNonQuery();
    ////Console.WriteLine("Create table address");

    //////table2
    //NpgsqlCommand command2 = new NpgsqlCommand(
    //"CREATE TABLE book (
    //id serial PRIMARY KEY,bookname VARCHAR (20) , nameauthor VARCHAR (30) NOT NULL, datepubl VARCHAR (30) not null,publisher VARCHAR (30) NOT NULL,address_id int not null,foreign key (address_id) references address(id))", connection);
    //command2.ExecuteNonQuery();


    //2 Delete table
    //NpgsqlCommand cmd2 = new NpgsqlCommand("DROP TABLE book", connection);
    //int count = cmd2.ExecuteNonQuery();

    //Console.WriteLine(count);



    //3 INSERT
    //NpgsqlCommand npgsql = new NpgsqlCommand("insert into address(country,city,street) values(@country,@city,@street)", connection);

    //npgsql.Parameters.AddWithValue("country", "Italy");
    //npgsql.Parameters.AddWithValue("city", "Rome");
    //npgsql.Parameters.AddWithValue("street", "Khhoefwf, 47");
    //int count = npgsql.ExecuteNonQuery();

    //Table 2

    NpgsqlCommand npgsql = new NpgsqlCommand("insert into book(bookname,nameauthor,datepubl,publisher,address_id) values(@bookname,@nameauthor,@datepubl,@publisher,@address_id)", connection);

    npgsql.Parameters.AddWithValue("bookname", "Harry Potter 2");
    npgsql.Parameters.AddWithValue("nameauthor", "Rouling Joan");
    npgsql.Parameters.AddWithValue("datepubl", "2012-06-15");
    npgsql.Parameters.AddWithValue("publisher", "Publisher2");
    npgsql.Parameters.AddWithValue("address_id", 2);
    int count = npgsql.ExecuteNonQuery();

    Console.WriteLine(count);
    Console.WriteLine("Done");



    ////3 SELECT

    //NpgsqlCommand cmd = new NpgsqlCommand("select * from address", connection);

    //var result = cmd.ExecuteReader();

    //while (result.Read())
    //{
    //   Console.WriteLine(string.Format("id:{0} - country:{1} - city:{2} - street:{3}", result.GetInt32(0).ToString(), result.GetString(1), result.GetString(2), result.GetString(3)));
    //}
    //result.Close();



    //table 2
    NpgsqlCommand cmd = new NpgsqlCommand("select * from book", connection);

    var result = cmd.ExecuteReader();

    while (result.Read())
    {
       Console.WriteLine(string.Format("id:{0} - bookname:{1} - nameauthor:{2} - datepublication:{3} - publisher:{4} - address_id:{5}", result.GetInt32(0).ToString(), result.GetString(1), result.GetString(2), result.GetString(3), result.GetString(4), result.GetInt32(5).ToString()));
    }
    result.Close();


    //4 UPDATE
    //NpgsqlCommand cmd2 = new NpgsqlCommand("update address set street=@street where id=@id", connection);
    //cmd2.Parameters.AddWithValue("id", 3);
    //cmd2.Parameters.AddWithValue("street", "ASjdifjggh, 77");
    //cmd2.ExecuteNonQuery();

    Console.WriteLine("Ok");


    //5 Від'єднаний режим
    NpgsqlCommand cmd5 = new NpgsqlCommand("select * from address", connection);

    NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(cmd5);

    dataAdapter.Fill(dataTable);

    

    if(dataTable.Rows.Count!=0)
    {
      for (int i = 0; i < dataTable.Rows.Count; i++)
       {
            for (int j = 0; j < dataTable.Columns.Count; j++)
            {
                Console.Write(dataTable.Rows[i][j] +"  ");
            }
            Console.WriteLine();
      }
  }



    NpgsqlCommand cmd6 = new NpgsqlCommand("select * from book", connection);

    NpgsqlDataAdapter dataAdapter2 = new NpgsqlDataAdapter(cmd6);

    dataAdapter2.Fill(dataTable);


    Console.WriteLine("Data from table BOOK:");
    if (dataTable.Rows.Count != 0)
    {
        for (int i = 0; i < dataTable.Rows.Count; i++)
        {
            for (int j = 0; j < dataTable.Columns.Count; j++)
            {
                Console.Write(dataTable.Rows[i][j] + "  ");
            }
            Console.WriteLine();
        }
    }



}
Console.ReadLine();