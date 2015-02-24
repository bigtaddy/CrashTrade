
http://coding.abel.nu/2012/03/ef-migrations-command-reference/

The first step is to enable migrations for our context:

1. Run the Enable-Migrations command in Package Manager Console

Code First Migrations has two primary commands that you are going to become familiar with.

2. Add-Migration will scaffold the next migration based on changes you have made to your model since the last migration was created

add-migration -ProjectName ResourceMetadata.Data -StartUpProjectName ResourceMetadata.API

3. Update-Database will apply any pending migrations to the database

 update-database -ProjectName ResourceMetadata.Data -StartUpProjectName ResourceMetadata.API