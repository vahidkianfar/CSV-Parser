# CSV-Parser

This App Contains 2 Main Folder and 3 Subfolder:

1. Models (Person class, Loading Data)
2. Dataset (Our CSV)
3. UI (MainMenu and SearchMenu)

In this project I created a simple CSV-Parser for specific type of CSV, but its highly expandale, I Stored the Columns and Rows into Objects from
Person Class and Retrieved Data by Query.

## Description:

We have a CSV File with 11 different column:
first_name, last_name, company_name, address, city, county, postal, phone1, phone2, email, and web.

we want to store this data into a Data Structure and retrieve that data, for the simplicity I created a Person Class and read all the data and stored it into
a List<Person>, each Person object have the CSV headers as Fields and then I Used LINQ.

## Challenge:

The Most challenge that I faced was splitting the Company Name Cause some of the fields has comma!
for exampl, compane_name: **Elliott, John W Esq**, basically when I wanted to split it by comma, it skipped the second part "John W Esq",
I had to create a RegEx to skip the comma within Quotation Mark:

```
var columns = Regex.Split(csvRowData, "[,]{1}(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
```
now I have a Array of String which I can easily put the element of the array into the Object's fields (properties).

