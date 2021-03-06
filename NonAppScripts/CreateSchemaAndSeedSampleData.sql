-- Run with postgress root user
-- Execute the command below to run this whole script like this in a command prompt
---- Linux/Windows: psql -U postgres -f CreateSchemaAndSeedSampleData.sql

-- create user and database
--DROP USER IF EXISTS filehub_owner;
CREATE USER filehub_owner WITH PASSWORD 'filehub_owner_password';
ALTER USER filehub_owner WITH SUPERUSER;

DROP DATABASE IF EXISTS filehub_db;
CREATE DATABASE filehub_db OWNER filehub_owner;
\connect filehub_db

-- Create Table FileRecord
DROP TABLE IF EXISTS "FileRecord";
CREATE EXTENSION IF NOT EXISTS "uuid-ossp";
CREATE TABLE "FileRecord" (
	"Id" uuid DEFAULT uuid_generate_v4 (), -- if id is not provided pg will automatically generate a guid for id. This is an extension needed for postgress 10
	"Name" varchar (300) NOT NULL,
	"Description" varchar (300),
	"Url" varchar (300),
	"Tags" varchar (300),
	"CreatedUtc" timestamptz NOT NULL,
	"UpdatedUtc" timestamptz NOT NULL,
	"DeletedUtc" timestamptz NOT NULL
);

-- Add values
INSERT INTO "FileRecord" ("Id", "Name", "Description", "Url", "Tags", "CreatedUtc", "UpdatedUtc", "DeletedUtc") VALUES ('10e6215d-b5c6-4896-987c-f30f3678f608', 'File record name 1.jpg', 'this is a Description', 'dummyurl.com', 'tag1, tag2', '2016-06-22', '2016-06-22', '9999-12-31' );
INSERT INTO "FileRecord" ("Id", "Name", "Description", "Url", "Tags", "CreatedUtc", "UpdatedUtc", "DeletedUtc") VALUES ('20cd8c99-4036-403d-bf84-cf8400f67836', 'File record name 2.jpg', 'this is a Description', 'dummyurl.com', 'tag1, tag2', '2016-06-22', '2016-06-22', '9999-12-31' );
INSERT INTO "FileRecord" ("Id", "Name", "Description", "Url", "Tags", "CreatedUtc", "UpdatedUtc", "DeletedUtc") VALUES ('30333df6-90a4-4fda-8dd3-9485d27cee36', 'File record name 3.jpg', 'this is a Description', 'dummyurl.com', 'tag1, tag2', '2016-06-22', '2016-06-22', '9999-12-31' );


-- Create Table File
DROP TABLE IF EXISTS "FhFile";
CREATE EXTENSION IF NOT EXISTS "uuid-ossp";
CREATE TABLE "FhFile" (
	"Id" uuid DEFAULT uuid_generate_v4 (), -- if id is not provided pg will automatically generate a guid for id. This is an extension needed for postgress 10
	"Name" varchar (300) NOT NULL,
	"FileRecordId" uuid,
	"CreatedUtc" timestamptz NOT NULL,
	"UpdatedUtc" timestamptz NOT NULL,
	"DeletedUtc" timestamptz NOT NULL,
	PRIMARY KEY ("Id")
);

-- Add values
INSERT INTO "FhFile" ("Id", "Name", "FileRecordId", "CreatedUtc", "UpdatedUtc", "DeletedUtc") VALUES ('50e6215d-b5c6-4896-987c-f30f3678f608', 'File name 1.jpg', '10e6215d-b5c6-4896-987c-f30f3678f608', '2016-06-22', '2016-06-22', '9999-12-31' );
INSERT INTO "FhFile" ("Id", "Name", "FileRecordId", "CreatedUtc", "UpdatedUtc", "DeletedUtc") VALUES ('60cd8c99-4036-403d-bf84-cf8400f67836', 'File name 2.jpg', '20cd8c99-4036-403d-bf84-cf8400f67836', '2016-06-22', '2016-06-22', '9999-12-31' );
INSERT INTO "FhFile" ("Id", "Name", "FileRecordId", "CreatedUtc", "UpdatedUtc", "DeletedUtc") VALUES ('70333df6-90a4-4fda-8dd3-9485d27cee36', 'File name 3.jpg', '30333df6-90a4-4fda-8dd3-9485d27cee36', '2016-06-22', '2016-06-22', '9999-12-31' );


-- Other helpful commands
----drop database -> dropdb -U postgres filehub_db
----connect to database -> psql -U filehub_owner filehub_db
----run queries (connect to db first) -> SELECT * FROM FileRecord; 
-- Table commands
---- see tables -> \d
---- see table schema -- \d [Table_Name]