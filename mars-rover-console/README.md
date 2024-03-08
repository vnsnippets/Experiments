====BY VIDUSH H. NAMAH====

A BRIEF OVERVIEW OF MY APPROACH

Developed using .NET Core 2.0 (C#)

The application was based on the ONION ARCHITECTURE.
With a certain similarity to MVC or MVVM - it takes decoupling and separation of concerns to the next level.

Typically it consists of layers each with a specific purpose.
Dependency is in a single direction (inwards).

Layers:
User Interface
Infrastructure (For Database connections etc - not needed in this application)
Service Implementation
Service Interfaces
Domain Entities

Each layer can have dependencies on layers BELOW it only.
Hence, the layers are properly decoupled with well-managed dependencies.
Each layer is a library on its own - built to be unit-testing-friendly.