<img width="400" img height="300" alt="Object Relational Mapping (ORM)" src="https://blog.berkaykanca.com/wp-content/uploads/2021/06/erenguvercin-databasefirst-codefirst-modelfirst.png">

# Object Relational Mapping (ORM)

ORM is used to bridge two different worlds and facilitate database operations for programmers in an easier and more consistent manner. Programmers used to be required to write SQL code directly for database operations. ORM eliminates this problem by automatically managing transformations between objects and the database, simplifying access to the database and its operations. ORM has three modeling techniques. These are:

- Database First
- Code First
- Model First

## 1. Database First

DB First, automatically generates an object model based on the existing database table structures, relationships, and other features. Of course, to achieve this automatic generation, we need to use a library. For example, if we are using a MsSql database, we need to install the following libraries:

- [Microsoft.EntityFrameworkCore.SqlServer](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/)
- [Microsoft.EntityFrameworkCore.Tools](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools/)

Just installing these extensions is not enough; we also need to use a method called "Scaffolding" to include the created database in the project. After opening the "Package Manager Console" in Visual Studio, we can use the following code to include our database in the project:

```Scaffold-DbContext "server=ServerName;database=DBName;uid=UserName;pwd=Passowrd;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models```

However, Database First technique has a disadvantage. Changes made in the database modeling are not automatically reflected in the project. We either need to perform manual operations within the project or use the "Scaffolding" method again to transfer the changes in the database.

[Database First Project](https://github.com/sonmezhakan).

## 2. Code First

Code First is a technique for creating a database and entity model with code. First, we need to create our entity classes within our project. If there are relationships between our entities, they should be specified. If customization of any properties of the objects is desired, it is possible to achieve this by performing Configuration operations. Finally, these tasks need to be transferred to the database side. To perform this transfer, we need to use a library. For example, if our database is MsSql, we need to install the following libraries:

- [Microsoft.EntityFrameworkCore.SqlServer](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/)
- [Microsoft.EntityFrameworkCore.Tools](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools/)

Of course, installing the extensions is not the only step. After opening the "Package Manager Console" in Visual Studio, you need to follow the steps below:

```add-migration versionName```

With this process, a database configuration/version file related to the created entities is generated. This step is necessary to transfer the changes made to the database model.

```update-database```

This operation ensures the transfer of the created configuration/version file to the database. If this step is not performed, the changes will not be applied to the database.

[Code First Project](https://github.com/sonmezhakan).

## 3. Model First

Model First, is created using a database design tool where you design database tables and relationships through a graphical user interface. You can use tools like Visual Studio for this technique.

[Code First Project](https://github.com/sonmezhakan).