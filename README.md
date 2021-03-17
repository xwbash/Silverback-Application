# Gorilla Wear Application
I wrote this program in 3 days, while in time I learned the sql language and C# FormSide


## Installation

You need to [Microsoft SQL ServerManagment](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15) to install database.

## Contributing
You can sign-up & sign-in with your sql server bought things it sends you a email as  </br>
<img src="https://i.imgur.com/4SgIqF2.png" data-canonical-src="https://i.imgur.com/4SgIqF2.png" width="450" height="200" />



## Database
Sorry idk how to export my database.
```
kullanici_data < is our database
tables;

adminside_orders
Columns; ID int IDENTITY(1,1) PRIMARY KEY, tarih, isim_soyisim, adres, urun_id, numara, mail

adres
Columns; ID int IDENTITY(1,1) PRIMARY KEY, mail, ulke, city

isim
Columns; ID int IDENTITY(1,1) PRIMARY KEY, isim, soyisim, nickname

kullanici_id
Columns; ID int IDENTITY(1,1) PRIMARY KEY, kullanici_adi

satin_gecmis
Columns; ID int IDENTITY(1,1) PRIMARY KEY, ayaknumara, fiyat, kullanici_nick, adres, urun_id

sifreler
Columns; ID int IDENTITY(1,1) PRIMARY KEY, sifre

stock
Columns; ID int IDENTITY(1,1) PRIMARY KEY, urun_isim, stock, price, urun_id

```
