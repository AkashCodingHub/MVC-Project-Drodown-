# MVC CRUD Application with Dropdown Dependencies

This project is an ASP.NET MVC application that demonstrates CRUD (Create, Read, Update, Delete) operations with cascading dropdowns for managing country, state, and city data.

## Features

- **CRUD Operations**:
  - Add, view, edit, and delete records for countries, states, and cities.
  
- **Cascading Dropdowns**:
  - Dropdowns dynamically populate based on the selected parent entity.
  - Selecting a country filters the states, and selecting a state filters the cities.

- **Database Integration**:
  - Uses **SQL Server** as the backend database.
  - Interacts with the database using **Entity Framework** or **ADO.NET**.

- **Responsive UI**:
  - Designed with Bootstrap for a clean and responsive user interface.
  - Supports modern browsers and mobile devices.

## Technologies Used

- **Frontend**: HTML, CSS, JavaScript, Bootstrap
- **Backend**: ASP.NET MVC (Model-View-Controller architecture)
- **Database**: SQL Server
- **ORM**: Entity Framework or ADO.NET (as per implementation)
- **Development Tools**: Visual Studio, Git

## Getting Started

### Prerequisites

- Install [Visual Studio](https://visualstudio.microsoft.com/).
- Install [SQL Server](https://www.microsoft.com/en-us/sql-server/).
- Clone the repository using Git:
  ```bash
  git clone <repository-url>
