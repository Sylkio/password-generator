# Password Generator

A secure password generation tool built with ASP.NET Core backend and React frontend. This project serves as both a learning platform and the foundation for a future extensible password management framework.

## Overview

This application provides a simple yet powerful way to generate secure passwords with customizable options. The backend API is built with ASP.NET Core, and the frontend is developed using React with TypeScript (Will be worked on)

This project has two main purposes:
1. **Learning Platform**: I Honestly made this project to deepen my understanding of modern .NET development, React with TypeScript, and secure API design
2. **Framework Foundation**: To eventually evolve into a comprehensive password management framework that others can build upon currently being me only.
   

## Features

- Generate random passwords with configurable options
- Quick "one-click" random password generation
- Password strength calculation
- Customizable password length and character types
- Clean, responsive user interface

## Tech Stack

### Backend
- ASP.NET Core
- C#
- RESTful API architecture

### Frontend
- React
- TypeScript
- Fetch API for backend communication

## Setup Instructions

### Prerequisites
- .NET 7 SDK or later
- Node.js and npm

### Backend Setup
1. Clone the repository
2. Navigate to the backend directory
3. Run `dotnet restore` to restore dependencies
4. Run `dotnet run` to start the API server

### Frontend Setup
1. Navigate to the frontend directory
2. Run `npm install` to install dependencies
3. Run `npm start` to start the development server

## API Endpoints

- `GET /api/password/RandomPassword`: Generates a random password with default settings
- `POST /api/password/GetPassword`: Generates one or more passwords based on custom criteria

## Roadmap

### Phase 1: Core Functionality (Current)
- ✅ Basic password generation API
- ✅ Simple React frontend
- ✅ Password strength calculation

### Phase 2: Enhanced Features
- [ ] User accounts for saving favorite password configurations
- [ ] Password history
- [ ] Copy to clipboard functionality
- [ ] Password generation analytics
- [ ] Mobile-responsive design improvements

### Phase 3: Advanced Features
- [ ] Password vault functionality
- [ ] Browser extension
- [ ] Password strength visualization
- [ ] Offline support
- [ ] Export/import functionality
- [ ] Dark/light theme

### Phase 4: Security & Performance
- [ ] End-to-end encryption
- [ ] Performance optimizations
- [ ] Comprehensive security audit
- [ ] Accessibility improvements

### Phase 5: Framework Development
- [ ] Refactor core components into a reusable library
- [ ] Create framework documentation and usage examples
- [ ] Develop plugin architecture
- [ ] Publish framework as NuGet package
- [ ] Create demo applications showcasing framework capabilities

## Contributing

Feel free to fork this project and submit pull requests. All contributions are welcome!
