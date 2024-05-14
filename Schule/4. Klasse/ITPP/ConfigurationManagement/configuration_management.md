# Configuration Management

## Basic Terms

-   CM: Configuration Management
-   CI: Configuration Item
-   CMS: Configuration Management System
-   CMDB: Configuration Management Database
-   ITSM: IT Service Management

## Basic Prinziple

Configuration Management offers data which is used in every IT process. Configuration Management deals with all CIs and their relation to services. The offered data is for example used here:

-   recognize and process incidents (errors)
-   assessing the impact of an incident
-   identify faulty equipment
-   identify users who may be affected by a problem

The data is stored in a configuration management system (CMS), which has interfaces to all other ITSM processes. The CMS also stores which support team is responsible for each incident category. The status of faulty CIs is maintained in Incident Management. Various ITSM processes can support Configuration Management in testing the infrastructure. For example:

-   when resolving incidents
-   when investigating problems
-   when implementing changes

## Configuration Items

A configuration item is the data set that contains all management relevant data as well as the history of a specific request. It always contains these columns in a database:

-   ID, Name, Type, Version, Supervisor, ...

## Usefullness and importance

CM can have a hugh impact and usefullness on many projects, especially IT projects, because it provides specific data which can be used to find the reason for errors faster. Morover, it helps engineering teams to build robust and stable systems through the use of tools that automatically manage and monitor updates to configuration data.

## Five steps of the configuration management process

There are five key steps to project configuration management:

-   **Planning**: A configuration management plan details how you will record, track, control, and audit configuration. This document is often part of the project quality management plan.
-   **Identification**: All configuration requirements on a project should be identified and recorded. This includes functionality requirements, design requirements, and any other specifications. The completion of this process results in the configuration baseline for the project.
-   **Control**: As the project scope is altered, the impact on the configuration must be assessed, approved, and documented. This is normally done within the project change control process.
-   **Status accounting**: Track your project’s configuration at all times. You should be able to tell your configuration's version and have a historical record of the old versions. It’s crucial to have an account of all versions so you can trace changes throughout the project.
-   **Audit**: This includes any tests to prove that the product conforms with the configuration requirements. Let’s say you built a report that must run within 10 seconds. The audit tests to see if the finished report actually runs that fast. Often, audits and checks will be built in at the completion of major project phases. This is so you can identify issues early.

The key difference to configuration management for Agile projects is in the identification step. Using Agile, the initial identification of specifications will be very general. It will be modified and updated frequently as the project progresses.

## Summary

Configuration Management (CM) is a set of practices, tools, and techniques used to manage changes in software, hardware, documentation, and other related items throughout their lifecycle. Configuration management items (CMI) refer to any item that needs to be tracked, managed, and controlled during the software development process. These can include source code, documentation, test cases, requirements, design specifications, and other related artifacts.

The database of a configuration management system (CMS) is a central repository that stores all the CMIs and tracks changes to them. The database typically includes metadata about the items such as version, author, date, and description. It also stores the history of changes made to the items, including who made the change, when it was made, and why it was made.

A configuration management system is a set of tools, processes, and procedures used to manage changes to CMIs. The goal of a configuration management system is to ensure that changes are made in a controlled manner, with proper documentation, and with minimal disruption to the development process. It typically includes a version control system, which allows developers to collaborate on code and other artifacts, and a build system, which automates the process of building and testing software.

In summary, CMIs are the items that need to be tracked and managed during the software development process, the database of a configuration management system is a central repository that stores all the CMIs and tracks changes to them, and the configuration management system is a set of tools, processes, and procedures used to manage changes to CMIs.

## Difference CM in projects and CM in companies

### Projects

CM in terms of IT means: an automated process which checks if the software changed is working as before (or even better). Unit Tests, Github Actions or other types of automated test have to run successfully every time after pushing new commits or more general making changes. If they fail, the team can instantly focus on fixing this issue, or just go back to the older code version, thanks to version controll...

CM in terms of all projects means: a systems engineering process for establishing consistency of a product's attributes throughout its life. Non-IT projects may focus on managing physical assets, such as equipment, materials, and facilities, as well as documentation and other project-related artifacts. Configuration Management in non-IT projects may involve tracking changes to project plans, schedules, and other documentation, as well as managing changes to physical assets and equipment.

### Companies

Configuration Management in companies involves managing changes to a broader set of assets, including software, hardware, and other digital assets, as well as physical assets such as equipment, facilities, and documentation. The goal of Configuration Management in companies is to maintain control over these assets and to ensure that they are managed in a consistent and efficient manner across the organization.

Another key difference between Configuration Management in projects and companies is that Configuration Management in companies typically involves more complex and mature processes and tools. This is because Configuration Management in companies often involves managing a much larger number of assets, across multiple teams or departments, and may require integration with other management systems such as change management, incident management, and asset management.

## Configuration Management

Maintain existing products and prevent errors from happening before they could happen: 2K-Problem
