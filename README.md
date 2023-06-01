# AuthenticyKeyAPI
Api application to search a key authentic and get the informations about the services of Registry.

I modified the logic from input validation removing Custom Exceptions and adding OneOf lib.
Through this lib, I send to controller a error message according failed type.
I created 4 error types and send to controller join a status code. (EmptyStringList, InvalidKey, NotJustDigitString and NotFoundKey)
In succes case, the main class fulfill the Json file, else the created types get back 404 and 400.

The tests project was modificated as well. The new unit tests, was created to vertifying the new methods from AuthenticKey project.
