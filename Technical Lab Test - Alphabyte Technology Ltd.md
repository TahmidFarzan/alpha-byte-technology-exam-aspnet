# **Technical Lab Test – Alphabyte Technology Ltd.**

Build a web application CRUD operation using .NET/.NET Core & MVC framework (bootstrap 5). You have to design a web form and show data in a data table. Web form data will be saved into the Oracle database and Data table data will be shown from the Oracle database. Design can be done in its own way. Here is the description of the form. 

|**Form Field Name** |**Input Type** |**Description** |
| - | - | - |
|*ID NUMBER* |Number |Mandatory field. |
|*Name* |Text |Mandatory field |
|*Division* |Select |Mandatory field |
|*Department* |Select |Mandatory field |
|*Date of Birth* |Date picker |Mandatory field |
|*Resume upload* |File |Mandatory field |

- **ID NUMBER** input number field. Mandatory field. Length 8 digits fixed. 
- **Name** input text field. Mandatory field. 
- **Division and department dropdown** will have a cascade relation e.g. if we select a division then the respective department of that division should be loaded in the department dropdown. Division and department are given to the following database. 
-  **Date of Birth** will be a date picker. Mandatory field. Need to validate the valid data string. 
- **Resume upload** can be done with file upload. Need to be validated that only PDF and DOC files are allowed to be uploaded. The file will be uploaded and saved to a folder of the application and the file path will be saved in the Oracle database. 
- **Save data** in the following Oracle database and the table is already given there. 

|**IP ADDRESS** |**USERNAME** |**PASSWORD** |**SERVICE NAME** |
| - | - | - | - |
|XXX.XXX.XXX.XXX |XXXXXXXX |XXXXXXXXXXXX |XX |

Data table data will be loaded from a database table. Here is the Data table example and description: 

|**ID NUMBER** |**NAME** |**DIVISION** |**Department** |**Date of Birth** |**Age** |**Resume** |**Action** |
| - | - | - | - | :- | - | - | - |
|10000001 |Ashraful Alam |IT |Software |07-Sep- 2020 |23 years 0 month 0 days |File1 |View Edit delete |

- **In the data table** the resume file name needs to be clickable and after clicking the file needs to be downloaded. 
- **In the data table,** the view button (action section) at the right side once clicked needs to show the person's information in a pop-up/ separate page. 
- **In the data table,** the edit button (action section) at the right side, should go to the edit page for information updates. 
- **In the data table,** the delete button (action section) on the right side, should take user consent before deleting the row. 
- **In the data table,** age will be calculated from date of birth to current date. 

If you have any questions feel free to contact us at [ career@alphabytetech.com ](mailto:career@alphabytetech.com)
