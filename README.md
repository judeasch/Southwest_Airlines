# Southwest_Airlines
## By Jude and Saraswoti (All code written by Jude unless otherwise specified in code comments)


## Built with
- OS: Windows 10 and Windows 11
- IDE: Visual Studio 2022
- Framework: .NET Core 8.0.2
- Code Template: ASP.NET Core Web App (Model-View-Controller)
- Database Manager: SQL Server 2019 and SQL Server 2022

## Current software requirements to run site
- Must have laptop/desktop computer (cannot be on mobile)
- Must have Visual Studio 2022
- Must have .NET Core 8.0.2 or better
- Must have SQL Server 2019 or better
- Recommended to have Windows 10 or better

## Purpose and audience
The Southwest_Airlines project is intended for both Southwest Airlines employees and customers. Broadly, it will achieve 4 main goals:
1. Allow customers to select their own seats on a flight
2. Allow customers to purchase a 'Fastpass', an optional upgrade to their ticket that will let them rebook a flight faster
3. Allow employees to verify a customer's ticket, including their chosen seat and whether or not they have a Fastpass
4. Collect and display data about Fastpass purchases and profits

## Tests run
1. **User:** Jude; **Test:** Verify the landing page is the login by going to the default url
     - **Results:** Success
2. **User:** Jude; **Test:** Verify the seat database is being retrieved and displayed correctly by going to the url (domain)/flights/detail/2
     - **Results:** Error. Upon debugging, I found that the seats were being retrieved, but there was an error in the logic to format them for display. Corrected