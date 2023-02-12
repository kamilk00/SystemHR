# SystemHR

The aim of the project was to develop a simple HR system based on WPF and a Microsoft SQL Server database. There are 3 tables in the database:
- Contracts
- Logins
- Workers

Passwords are hashed with salt and stored in a database. For this purpose, the SHA256 algorithm was used.

Firstly, the user needs to login to the system.

![image](https://user-images.githubusercontent.com/92810145/218327534-6f921da1-8bd5-4122-8280-8cde89ddff5c.png)

Admin has some options, like:
- checking details about each worker or contract, 
- adding or removing a worker, 
- adding or ending the worker's contract,
- changing password.

![image](https://user-images.githubusercontent.com/92810145/218327617-5be04664-9011-48af-af19-5ab49d8d3e28.png)

The worker can edit personal information in the system or change the password. The worker can also see the list of all workers, but only without details. 

![image](https://user-images.githubusercontent.com/92810145/218328415-efc5efc2-c47c-4c54-9113-8c39eac65b55.png)
