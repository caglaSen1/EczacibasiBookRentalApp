# **Book Rental**

This project is a book rental project written in .Net. 

Books, categories of books and customers can be added to the system. Customers can rent more than one book until a certain date. Since the books they rent are unavailable, others cannot rent them from the system. Books that customers have rented but have not yet delivered and books that have been delivered are kept in the system within rentedBooks table.
## Category

- Post/categories

It takes Name(required) and Description parameters. Category name is unique and no new category can be created with the same name.

- Get / categories

Returns all categories. By entering page and pageSize values, it can be set how many categories will be on a page and on which page the categories will be displayed.

- DELETE / categories

Deletes the category given the id parameter. Returns the deleted category. Returns an error if the category given id is already deleted.

- GET /name/{name}

takes name(required) and withBooks(boolean) parameters. It takes the name of the category and shows the information of the category with that name. If withBooks is true, it also lists the books belonging to that category.

- PUT /categories/{id}

Updates the name and description of the category whose id is given. If the newly entered category name already exists, it does not update and returns error.

## Book

- POST /books

Takes parameters: Title(required), Author(required), Publisher(required), Translator(required), ISBN(required), Page, FirstEditionYear, Language, Price(required), CategoryId(required). It checks the parameters in case they are not entered correctly. For example, price and page cannot be negative. Adds the book and returns the added book.

- GET /books

Returns all books. page and pageSize values can be set to set how many books are on a page and which page to display. sortBy parameter can be set to alphabetic, ascending or descending to sort the books in the desired order. (It is case sensitive and it is default if nothing is typed)

- GET /books/{id}

Returns the book whose id value is entered. WithCategory option, it is determined whether the category information of the returned book will be included or not.

- DELETE /books/{id}

Deletes the book given id parameter. Returns the deleted book. Returns an error if the book given id is already deleted.

- GET /title/{title}

Returns the book given the title value. The desired output can be obtained withCategory and sortBy options.

- GET /ISBN/{ISBN}

Returns the book given the ISBN value. WithCategory and sortBy options, the desired output can be obtained.

- GET /books/search

title, author, publisher, ISBN, categoryId, minPrice, categoryName, isAvailable, sortBy parameters are entered to search for books.

If isAvailable is not selected, all the books with and without a customer are instantly retrieved.

- PUT/ books/{id}

Title, Author, Publisher, Translator, ISBN, Page, FirstEditionYear, Language, Price, CategoryId. id allows to update other properties of the given book. 

If the id value is entered incorrectly, it gives a book not found error.

## Customer

- POST /customers

Takes parameters FirstName(required), LastName(required), Address, Phone(required) and Email(required). Checks the parameters in case they are not entered correctly. Returns the added customer. Phone and Email are unique and returns error if another customer's phone or email is entered.

- GET /books

Returns all customers. page and pageSize values can be set to set how many customers will be on a page and which customers will be shown on which page.

- GET /customers/{id}

Returns the customer given the id value. If the id value is entered incorrectly, it returns a customer not found error.

- DELETE /books/{id}

Deletes the customer given id parameter. Returns the deleted customer. Returns an error if the book with id is already deleted.

- GET /email{email}

Returns the customer given the email value. If the email is entered incorrectly or if there is no customer to which it belongs, a Not Found error is returned.

- GET /phone{phone}

Returns the customer given the phone value. If phone is entered incorrectly or there is no customer it belongs to, a Not Found error is returned.

## Rented Book

- POST /rentedBooks

Takes CustomerId, BookId and HowManyDaysToRent parameters. Adds the customer and the book to rent. Returns error if the book is rented by another customer. Returns error if the given CustomerId or BookId is incorrect. 

- GET /rentedBooks

Returns all rented books. page and pageSize can be set to set how many on a page and on which page the rented books will be displayed.

- DELETE /rentedBooks/{id}

Deletes the rented book given id parameter. Returns the rented book it deleted. Returns an error if the rented book with id has already been deleted.

- GET /rentedBooks/search

returns the appropriate rented books taking customerId, bookId and howManyDaysToRent parameters.

- PATCH /rentedBooks/deliverereBook/{id}

When a book rented by a customer is returned, it generates the return date of the rented book (the rented book is still in rentedBooks table) and makes the book available for pickup by other customers.

- GET /getCurrentRentals

It takes no parameters. Returns books that are not currently available for collection, that is, books belonging to a customer.

- GET /getOverdueRentals

It does not take parameters. Returns books that are currently available for to take, i.e. books that have been returned by a customer.

![image](https://github.com/caglaSen1/EczacibasiBookRentalApp/assets/75044298/a06c3e84-28b8-44cc-be63-4f219865c202)
![image](https://github.com/caglaSen1/EczacibasiBookRentalApp/assets/75044298/02edf273-81c6-46ef-99fc-327675605bcc)
![image](https://github.com/caglaSen1/EczacibasiBookRentalApp/assets/75044298/4c8d2a49-650a-47e1-bc59-cc0e81be42d2)
![image](https://github.com/caglaSen1/EczacibasiBookRentalApp/assets/75044298/897638ee-a8f2-4769-9da6-a6f5aa44106f)

## Category - some swagger images

![Untitled](Category%20-%20swagger%20images%209ebaec2c047d4589ade5e3f7044eccdb/Untitled.png)

![Untitled](Category%20-%20swagger%20images%209ebaec2c047d4589ade5e3f7044eccdb/Untitled%201.png)

![Untitled](Category%20-%20swagger%20images%209ebaec2c047d4589ade5e3f7044eccdb/Untitled%202.png)

![Untitled](Category%20-%20swagger%20images%209ebaec2c047d4589ade5e3f7044eccdb/Untitled%203.png)

![Untitled](Category%20-%20swagger%20images%209ebaec2c047d4589ade5e3f7044eccdb/Untitled%204.png)

![Untitled](Category%20-%20swagger%20images%209ebaec2c047d4589ade5e3f7044eccdb/Untitled%205.png)

![Untitled](Category%20-%20swagger%20images%209ebaec2c047d4589ade5e3f7044eccdb/Untitled%206.png)

![Untitled](Category%20-%20swagger%20images%209ebaec2c047d4589ade5e3f7044eccdb/Untitled%207.png)

![Untitled](Category%20-%20swagger%20images%209ebaec2c047d4589ade5e3f7044eccdb/Untitled%208.png)

![Untitled](Category%20-%20swagger%20images%209ebaec2c047d4589ade5e3f7044eccdb/Untitled%209.png)

## Book - swagger images

![Untitled](Book%20-%20swagger%20images%20683f2701c413463e8dbfbc09900a2a1c/Untitled.png)

![Untitled](Book%20-%20swagger%20images%20683f2701c413463e8dbfbc09900a2a1c/Untitled%201.png)

![Untitled](Book%20-%20swagger%20images%20683f2701c413463e8dbfbc09900a2a1c/Untitled%202.png)

![Untitled](Book%20-%20swagger%20images%20683f2701c413463e8dbfbc09900a2a1c/Untitled%203.png)

![Untitled](Book%20-%20swagger%20images%20683f2701c413463e8dbfbc09900a2a1c/Untitled%204.png)

![Untitled](Book%20-%20swagger%20images%20683f2701c413463e8dbfbc09900a2a1c/Untitled%205.png)

![Untitled](Book%20-%20swagger%20images%20683f2701c413463e8dbfbc09900a2a1c/Untitled%206.png)

![Untitled](Book%20-%20swagger%20images%20683f2701c413463e8dbfbc09900a2a1c/Untitled%207.png)

![Untitled](Book%20-%20swagger%20images%20683f2701c413463e8dbfbc09900a2a1c/Untitled%208.png)

![Untitled](Book%20-%20swagger%20images%20683f2701c413463e8dbfbc09900a2a1c/Untitled%209.png)

![Untitled](Book%20-%20swagger%20images%20683f2701c413463e8dbfbc09900a2a1c/Untitled%2010.png)

![Untitled](Book%20-%20swagger%20images%20683f2701c413463e8dbfbc09900a2a1c/Untitled%2011.png)

![Untitled](Book%20-%20swagger%20images%20683f2701c413463e8dbfbc09900a2a1c/Untitled%2012.png)

![Untitled](Book%20-%20swagger%20images%20683f2701c413463e8dbfbc09900a2a1c/Untitled%2013.png)

![Untitled](Book%20-%20swagger%20images%20683f2701c413463e8dbfbc09900a2a1c/Untitled%2014.png)

![Untitled](Book%20-%20swagger%20images%20683f2701c413463e8dbfbc09900a2a1c/Untitled%2015.png)

![Untitled](Book%20-%20swagger%20images%20683f2701c413463e8dbfbc09900a2a1c/Untitled%2016.png)

![Untitled](Book%20-%20swagger%20images%20683f2701c413463e8dbfbc09900a2a1c/Untitled%2017.png)

