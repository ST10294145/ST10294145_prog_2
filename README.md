# ST10294145_prog_2

## Reason for switch
Reason for the switch from WPF to MVC is due to comfortablablity in templates for the POE.


# ST10294145_prog_2 - Contract Monthly Claim System
This is a Contract Monthly Claim System built with ASP.NET Core MVC. It allows users to submit claims, manage claims, upload documents, and view claim status. It includes functionality for role-based dashboards (Lecturers vs. other users) and provides unit tests using xUnit and Moq.

Features
Submit Claims: Users can submit new claims.
View Dashboard: Users can view submitted claims.
Lecturers have a personalized dashboard displaying their own claims.
Other users see all claims in the system.
Approve/Reject Claims: Admins can update the status of claims.
Upload Documents: Users can upload supporting documents for their claims.
Role-based Access: Different views and functionality based on user roles.
Session-based Authentication: Determines user roles and handles dashboard access.
Technologies Used
ASP.NET Core MVC: Backend framework for creating the web application.
Entity Framework (In-Memory): Used to store claims data in memory.
Azure Blob Storage (Demo): Uploads supporting documents for claims (in real scenarios, Azure Blob Storage could be used).
Session Management: Session-based authentication for determining user roles.
Unit Testing: xUnit and Moq for testing controllers and functionality.
Getting Started
Prerequisites
.NET 6 SDK or later
Visual Studio or VS Code (preferred IDE)
Basic understanding of ASP.NET Core and MVC pattern





# Usage
Submitting a Claim
Navigate to /Claims/SubmitClaim.
Fill out the claim form and submit the claim.
Claims are stored in-memory and can be viewed on the dashboard.
Viewing the Dashboard
Lecturers can view only their claims.
Other users can view all claims in the system.
Updating Claim Status
Admin users can approve or reject claims by updating their status on the dashboard.
Uploading Supporting Documents
Users can upload supporting documents while submitting claims.
Documents are saved in the wwwroot/uploads folder.
Future Enhancements
Database Integration: Replace in-memory data with a relational database such as SQL Server.
Authentication/Authorization: Implement role-based access control using Identity or JWT.
Cloud Storage: Integrate with Azure Blob Storage for document uploads.
Email Notifications: Send email notifications for claim status updates.
