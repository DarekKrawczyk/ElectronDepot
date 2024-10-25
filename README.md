# ElectroDepot

## Project Overview
ElectroDepot is a comprehensive inventory management application for electronic components, designed to help users keep track of their integrated circuits (ICs) and other electronic parts. Many electronics enthusiasts and professionals accumulate a variety of components over time and often lose track of what they own or need to purchase. This project provides a solution to that problem by maintaining a digital inventory of electronic parts through a client-server architecture.

## Purpose
ElectroDepot was created to address the common issue of disorganized component storage. Users often find themselves with components they forgot they owned or are unsure if they need to order specific parts. By tracking what’s on hand and what’s used in projects, ElectroDepot makes it easier to manage component stock, plan projects, and automate updates on new purchases.

## Features

### Server
- **Database of Components**: Stores a database of electronic components for each user, tracking available stock and usage history.
- **REST API**: Provides a REST API that allows clients to retrieve data from the database and interact with stored information.
- **Automated Order Tracking**: Automatically updates inventory by scanning emails or notifications from popular electronics suppliers (e.g., Allegro, Botland, Kamami, MSalamon, and AliExpress).
- **Project Usage Tracking**: Tracks and stores information on which components were used in specific projects, allowing users to see part usage by project.

### Client
- **Cross-Platform Interface**: Offers a desktop or web interface built in C# and possibly .NET MAUI for cross-platform support, allowing users to interact with the server, check stock levels, and manage inventory.
- **Filtering, Sorting, and Searching**: Allows users to filter, sort, and search through their inventory to quickly find specific parts.
- **Component Management**: Users can add new components or update details on existing ones.
- **Project Management**: Enables users to create new projects and assign components for easy tracking of project needs.
- **Notification Configuration**: Supports the setup of email and notification services to automatically add purchased parts to the inventory.
- **User Authentication**: Supports user login to secure personal inventory and project data.

## Architecture and Modules

The ElectroDepot project consists of several core modules:

1. **Server Module**
   - Developed in **C# with ASP.NET Core**, providing a REST API that enables interactions with the component database.
   - Supports a **web-scraping module** written in C# to parse email notifications and automatically update the inventory based on purchase confirmations.

2. **Client Module**
   - A cross-platform client application, developed in **C#** and potentially **.NET MAUI** for compatibility across Windows, macOS, iOS, and Android.
   - Includes a **class library** for client-side operations, handling UI interactions, data management, and project tracking.
   
3. **REST API Class Library**
   - A dedicated library that handles REST API calls, encapsulating all interactions with the server and ensuring reliable communication between the client and server.
   - Comprehensive **unit tests** for this library to ensure reliable performance and error handling.

4. **Monitoring and Update Module**
   - A module responsible for monitoring purchase activity and updating the component database in real time whenever a new item is bought.
   - Supports integration with third-party services and email parsing to track incoming parts and update stock levels automatically.

5. **Client-Side Code Library**
   - A reusable class library designed to support various client-side operations, including filtering, sorting, and managing component data, ensuring a consistent experience across platforms.

---

ElectroDepot is a tailored solution for electronics enthusiasts and professionals who need an organized, automated, and searchable way to manage their electronic components. This project ensures users always know what they have on hand and where components are being utilized in their projects.
