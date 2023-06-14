# Book Rental API

### This project is a book rental API written in .NET. 
Books, categories of books and customers can be added to the system. Customers can rent more than one book until a certain date. Since the books they rent are unavailable, others cannot rent them from the system. Books that customers have rented but have not yet delivered and books that have been delivered are kept in the system within rentedBooks table.


## Category

### POST /categories

Adds a new category to the system.

- Request parameters:
  - Name (required): The name of the category (must be unique).
  - Description: The description of the category.

### GET /categories

Retrieves all categories.

- Request parameters:
  - page: The page number for pagination.
  - pageSize: The number of categories per page.

### DELETE /categories/{id}

Deletes the category with the specified ID.

- Request parameters:
  - id: The ID of the category to delete.

### GET /categories/name/{name}

Retrieves the information of the category with the specified name.

- Request parameters:
  - name (required): The name of the category.
  - withBooks: Specifies whether to include the books belonging to the category.

### PUT /categories/{id}

Updates the name and description of the category with the specified ID. If the newly entered category name already exists, it does not update and returns error.

- Request parameters:
  - id: The ID of the category to update.
  - Name: The new name for the category.
  - Description: The new description for the category.

## Book

### POST /books

Adds a new book to the system.

- Request parameters:
  - Title (required): The title of the book.
  - Author (required): The author of the book.
  - Publisher (required): The publisher of the book.
  - Translator (required): The translator of the book.
  - ISBN (required): The ISBN of the book.
  - Page: The number of pages in the book.
  - FirstEditionYear: The year of the first edition of the book.
  - Language: The language of the book.
  - Price (required): The price of the book.
  - CategoryId (required): The ID of the category to which the book belongs.

### GET /books

Retrieves all books.

- Request parameters:
  - page: The page number for pagination.
  - pageSize: The number of books per page.
  - sortBy: Sorts the books in the desired order (alphabetic, ascending, or descending).

### GET /books/{id}

Retrieves the book with the specified ID.

- Request parameters:
  - id: The ID of the book to retrieve.
  - withCategory: Specifies whether to include the category information of the book.

### DELETE /books/{id}

Deletes the book with the specified ID.

- Request parameters:
  - id: The ID of the book to delete.

### GET /books/title/{title}

Retrieves the book with the specified title.

- Request parameters:
  - title: The title of the book.
  - withCategory: Specifies whether to include the category information of the book.
  - sortBy: Sorts the books in the desired order (alphabetic, ascending, or descending).

### GET /books/ISBN/{ISBN}

Retrieves the book with the specified ISBN.

- Request parameters:
  - ISBN: The ISBN of the book.
  - withCategory: Specifies whether to include the category information of the book.
  - sortBy: Sorts the books in the desired order (alphabetic, ascending, or descending).

### GET /books/search

Searches for books based on various criteria.

- Request parameters:
  - title: The title of the book.
  - author: The author of the book.
  - publisher: The publisher of the book.
  - ISBN: The ISBN of the book.
  - categoryId: The ID of the category to which the book belongs.
  - minPrice: The minimum price of the book.
  - categoryName: The name of the category to which the book belongs.
  - isAvailable: Specifies whether to retrieve only available books.
  - sortBy: Sorts the books in the desired order (alphabetic, ascending, or descending).

### PUT /books/{id}

Updates the properties of the book with the specified ID.

- Request parameters:
  - id: The ID of the book to update.
  - Title: The new title of the book.
  - Author: The new author of the book.
  - Publisher: The new publisher of the book.
  - Translator: The new translator of the book.
  - ISBN: The new ISBN of the book.
  - Page: The new number of pages in the book.
  - FirstEditionYear: The new year of the first edition of the book.
  - Language: The new language of the book.
  - Price: The new price of the book.
  - CategoryId: The new ID of the category to which the book belongs.

## Customer

### POST /customers

Adds a new customer to the system.

- Request parameters:
  - FirstName (required): The first name of the customer.
  - LastName (required): The last name of the customer.
  - Address: The address of the customer.
  - Phone (required): The phone number of the customer (must be unique).
  - Email (required): The email address of the customer (must be unique).

### GET /customers

Retrieves all customers.

- Request parameters:
  - page: The page number for pagination.
  - pageSize: The number of customers per page.

### GET /customers/{id}

Retrieves the customer with the specified ID.

- Request parameters:
  - id: The ID of the customer to retrieve.

### DELETE /customers/{id}

Deletes the customer with the specified ID.

- Request parameters:
  - id: The ID of the customer to delete.

### GET /customers/email/{email}

Retrieves the customer with the specified email address. If the email is entered incorrectly or if there is no customer to which it belongs, a Not Found error is returned.

- Request parameters:
  - email: The email address of the customer.

### GET /customers/phone/{phone}

Retrieves the customer with the specified phone number. If phone is entered incorrectly or there is no customer it belongs to, a Not Found error is returned.

- Request parameters:
  - phone: The phone number of the customer.

## Rented Book

### POST /rentedBooks

Rents a book to a customer.
The date on which the book must be returned is automatically assigned

- Request parameters:
  - CustomerId: The ID of the customer who is renting the book.
  - BookId: The ID of the book to be rented.
  - HowManyDaysToRent: The number of days the book will be rented for.

### GET /rentedBooks

Retrieves all rented books.

- Request parameters:
  - page: The page number for pagination.
  - pageSize: The number of rented books per page.

### DELETE /rentedBooks/{id}

Deletes the rented book with the specified ID.

- Request parameters:
  - id: The ID of the rented book to delete.

### GET /rentedBooks/search

Searches for rented books based on various criteria.

- Request parameters:
  - customerId: The ID of the customer who rented the book.
  - bookId: The ID of the rented book.
  - howManyDaysToRent: The number of days the book is rented for.

### PATCH /rentedBooks/delivererBook/{id}
returnDate is set when the rented book is delivered, the book becomes available 
Marks a rented book as returned (giving the ReturnDate), making book available for other customers to rent.

- Request parameters:
  - id: The ID of the rented book.

### GET /getCurrentRentals

Retrieves the books that are currently rented and not available for rental.

### GET /getOverdueRentals

Retrieves the books that have been returned by customers and are currently available for rental.

# Images

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled.png)

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%201.png)

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%202.png)

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%203.png)


## Category - Some swagger images 


![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%204.png)

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%205.png)

###  If we enter a category name that already exists it returns error:

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%206.png)

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%207.png)

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%208.png)

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%209.png)


### If withBooks selected true, it also returns the books belonging to the category:

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2012.png)

## Book - Some swagger images 

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2013.png)

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2014.png)

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2015.png)

### sortBy; if alphabetical is selected, it brings all books with names in alphabetical order, if ascending or descending is selected, it brings all books with price is ascending or descending, if nothing is entered, books come by default:

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2016.png)

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2017.png)

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2018.png)

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2019.png)

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2020.png)

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2021.png)

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2022.png)

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2023.png)

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2024.png)

### If the id value of the non-existent book is given, the update does not occur:

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2025.png)

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2026.png)

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2027.png)

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2028.png)

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2029.png)

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2030.png)

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2031.png)

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2032.png)

## Customer - Some swagger images 

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2033.png)

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2034.png)

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2035.png)

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2036.png)

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2037.png)

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2038.png)

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2039.png)

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2040.png)

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2041.png)

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2042.png)

### If the id value of the non-existent customer is given, the deletion does not occur. Returns Not Found error:

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2043.png)

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2044.png)

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2045.png)

### When updating the category name/email, it checks if there is another category with that name/email. If there is, it does not update and returns error:

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2010.png)

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2011.png)


![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2046.png)

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2047.png)

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2048.png)

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2049.png)

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2050.png)

## RentedBook - Some swagger images 

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2051.png)

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2052.png)

### If you want to rent a book to a customer who is not available (the book is currently with another customer), "Book is not available" error is returned:

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2053.png)

### Books return with isAvailable property:

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2054.png)

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2055.png)

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2056.png)

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2057.png)

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2058.png)

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2059.png)

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2060.png)

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2061.png)

### When the book is delivered, the returnDate value is created and isAvailable becomes true:

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2062.png)

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2063.png)

### Returns books that are momentarily with a customer:

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2064.png)

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2065.png)

### Returns books that used to be rented but are now available:

![Untitled](Untitled%20274f7fe955814bee8d28b5e4ca59e349/Untitled%2066.png)
