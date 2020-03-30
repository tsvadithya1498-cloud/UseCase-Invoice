CREATE TABLE Company
(
	 CompanyId			VARCHAR(6)		PRIMARY KEY
	,CompanyName		NVARCHAR(50)	NOT NULL
	,AddressLine1		NVARCHAR(50)	NOT NULL
	,AddressLine2		NVARCHAR(50)
	,City				NVARCHAR(20)	NOT NULL
	,State				NVARCHAR(15)	NOT NULL
	,Zipcode			INT				NOT NULL
	,Country			VARCHAR(20)		NOT NULL
	,Phone				VARCHAR(20)
	,Email				VARCHAR(50)
)

CREATE TABLE Invoice
(
	 InvoiceId								VARCHAR(20)		PRIMARY KEY
	,CompanyId								VARCHAR(6)		FOREIGN KEY REFERENCES Company(CompanyId)
	,Date									DATE			NOT NULL
	,BillingContactName						VARCHAR(25)
	,ShippingContactName					VARCHAR(25)
	,ShippingCompanyName					NVARCHAR(50)	NOT NULL
	,ShippingAddressLine1					NVARCHAR(50)	NOT NULL
	,ShippingAddressLine2					NVARCHAR(50)
	,ShippingCity							NVARCHAR(20)	NOT NULL
	,ShippingState							NVARCHAR(15)	NOT NULL
	,ShippingZipcode						INT				NOT NULL
	,ShippingCountry						VARCHAR(20)		NOT NULL
	,ShippingPhone							VARCHAR(20)
	,ShippingEmail							VARCHAR(50)
	,SubTotal								DECIMAL(10,2)	NOT NULL
	,Discount								DECIMAL(10,2)
	,GrandTotal								DECIMAL(10,2)	NOT NULL
	,TaxRate								DECIMAL(8,2)
	,TaxAmount								DECIMAL(10,2)
	,ShippingCharges						DECIMAL(10,2)
	,Balance								DECIMAL(10,2)	NOT NULL
	,Remarks								NVARCHAR(500)
)

CREATE TABLE InvoiceDetails
(
	 InvoiceDetailId						INT PRIMARY KEY	IDENTITY(1,1)
	,InvoiceId								VARCHAR(20) FOREIGN KEY REFERENCES Invoice(InvoiceId)
	,Description							VARCHAR(25)		NOT NULL
	,Price									DECIMAL(10,2)	NOT NULL
	,Quantity								INT				NOT NULL
	,Total									DECIMAL(10,2)	NOT NULL
)