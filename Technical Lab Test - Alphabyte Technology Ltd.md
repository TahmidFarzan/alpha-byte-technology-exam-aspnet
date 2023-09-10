# **Technical Lab Test – Alphabyte Technology Ltd.**

Build a web application CRUD operation using .NET/.NET Core & MVC framework (bootstrap 5). You have to design a web form and show data into a data table. Web form data will be save into oracle database and Data table data will be show from oracle database. Design can be done at own way. Here is the description of the form. 

|**Form Field Name** |**Input Type** |**Description** |
| - | - | - |
|*ID NUMBER* |Number |Mandatory field. |
|*Name* |Text |Mandatory field |
|*Division* |Select |Mandatory field |
|*Department* |Select |Mandatory field |
|*Date of Birth* |Date picker |Mandatory field |
|*Resume upload* |File |Mandatory field |

- **ID NUMBER** input number field. Mandatory field. Length 8 digit fixed. 
- **Name** input text field. Mandatory field. 
- **Division and department dropdown** will have cascade relation e.g. if we select a division thenthe respective department of that division should be loaded in department dropdown. Division and department are given to the following database. 
-  **Date of Birth** will be a date picker. Mandatory field. Need to validate the valid data string. 
- **Resume upload** can be done with file upload. Need to be validated that only PDF and DOC files areallowed to upload. File will upload and save to a folder of the application and file path will be saved in oracle database. 
- **Save data** in the following oracle database and table is already given there. 

|**IP ADDRESS** |**USERNAME** |**PASSWORD** |**SERVICE NAME** |
| - | - | - | - |
|XXX.XXX.XXX.XXX |XXXXXXXX |XXXXXXXXXXXX |XX |

Data table data will be load from database table. Here is the Data table example and description: 

|**ID NUMBER** |**NAME** |**DIVISION** |**Department** |**Date of Birth** |**Age** |**Resume** |**Action** |
| - | - | - | - | :- | - | - | - |
|10000001 |Ashraful Alam |IT |Software |07-Sep- 2020 |23 years 0 month 0 days |File1 |View Edit delete |

- **In the data table** resume file name need to be clickable and after clicking the file need to bedownloaded. 
- **In the data table,** the view button (action section) at the right side once clicked needs toshow the person's information in a pop-up/ separate page. 
- **In the data table,** the edit button (action section) at the right side, should go to the edit page forinformation updates. 
- **In the data table,** the delete button (action section) at the right side, should take user consent beforedeleting the row. 
- **In the data table,** age will be calculated from date of birth to current date. 

If you have any question feel free to contact us[ career@alphabytetech.com ](mailto:career@alphabytetech.com)
