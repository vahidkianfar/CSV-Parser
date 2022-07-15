# CSV-Parser

This App Contains 2 Main Folder and 3 Subfolder:

1. Models (Person class, Loading Data)
2. Dataset (Our CSV)
3. UI (MainMenu, SearchMenu, LiveTable)

In this project I created a simple CSV-Parser for specific type of CSV, but its highly expandale, I Stored the Columns and Rows into Objects from
Person Class and Retrieved Data by Query.

## App Menu:

![](https://github.com/vahidkianfar/CSV-Parser/blob/master/CSV-Parser/Gif/CSV-Parser-VS.gif)


## Description:

We have a CSV File with 11 different columns:
first_name, last_name, company_name, address, city, county, postal, phone1, phone2, email, and web.

we want to store this data into a Data Structure and retrieve that data, for the simplicity I created a Person Class and read all the data and stored it into
a List<Person>, each Person object have the CSV headers as Fields and then I Used LINQ.

## Challenge:

The Most challenge that I faced was splitting the Company Name, cause some of the fields has comma!
for example, company_name: **"Elliott, John W Esq"**, basically when I wanted to split it by comma, it skipped the second part **John W Esq**,
I had to create a RegEx to skip the comma within Quotation Mark:

```
var columns = Regex.Split(csvRowData, "[,]{1}(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
```
now I have an array of string which I can easily put the elements of the array into the Object's fields (properties).

