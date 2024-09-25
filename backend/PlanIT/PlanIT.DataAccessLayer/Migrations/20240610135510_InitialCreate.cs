using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PlanIT.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectRoles",
                columns: table => new
                {
                    ProjectRoleID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProjectRoleName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectRoles", x => x.ProjectRoleID);
                });

            migrationBuilder.CreateTable(
                name: "TimeEntries",
                columns: table => new
                {
                    TimeEntryID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserID = table.Column<int>(type: "INTEGER", nullable: false),
                    ProjectID = table.Column<int>(type: "INTEGER", nullable: true),
                    AssignmentID = table.Column<int>(type: "INTEGER", nullable: true),
                    StartTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DurationInMinutes = table.Column<int>(type: "INTEGER", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeEntries", x => x.TimeEntryID);
                });

            migrationBuilder.CreateTable(
                name: "TimeRegions",
                columns: table => new
                {
                    TimeRegionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TimeRegionName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeRegions", x => x.TimeRegionId);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserRoleID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserRoleName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.UserRoleID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Token = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    PictureURL = table.Column<string>(type: "TEXT", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TimeRegionID = table.Column<int>(type: "INTEGER", nullable: false),
                    Activated = table.Column<int>(type: "INTEGER", nullable: false),
                    UserRoleID = table.Column<int>(type: "INTEGER", nullable: false),
                    DarkTheme = table.Column<int>(type: "INTEGER", nullable: false),
                    Language = table.Column<string>(type: "TEXT", nullable: false),
                    PushEmailSettings = table.Column<int>(type: "INTEGER", nullable: false),
                    PushNotificationSettings = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_TimeRegions_TimeRegionID",
                        column: x => x.TimeRegionID,
                        principalTable: "TimeRegions",
                        principalColumn: "TimeRegionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_UserRoles_UserRoleID",
                        column: x => x.UserRoleID,
                        principalTable: "UserRoles",
                        principalColumn: "UserRoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    NotificationID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserID = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    SenderID = table.Column<int>(type: "INTEGER", nullable: false),
                    Read = table.Column<bool>(type: "INTEGER", nullable: false),
                    AssignmentId = table.Column<int>(type: "INTEGER", nullable: true),
                    ProjectId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.NotificationID);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProjectName = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ProjectLeaderID = table.Column<int>(type: "INTEGER", nullable: false),
                    UserID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectID);
                    table.ForeignKey(
                        name: "FK_Projects_Users_ProjectLeaderID",
                        column: x => x.ProjectLeaderID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "AssignmentLists",
                columns: table => new
                {
                    AssignmentListID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AssignmentListName = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ProjectID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignmentLists", x => x.AssignmentListID);
                    table.ForeignKey(
                        name: "FK_AssignmentLists_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KanbanColumns",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "INTEGER", nullable: false),
                    ProjectID = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    Index = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KanbanColumns", x => new { x.UserID, x.ProjectID, x.Status });
                    table.ForeignKey(
                        name: "FK_KanbanColumns_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KanbanColumns_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserProjects",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "INTEGER", nullable: false),
                    ProjectID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProjects", x => new { x.UserID, x.ProjectID });
                    table.ForeignKey(
                        name: "FK_UserProjects_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProjects_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    AssignmentID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AssignmentName = table.Column<string>(type: "TEXT", nullable: false),
                    AssignmentLeadID = table.Column<int>(type: "INTEGER", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    Priority = table.Column<string>(type: "TEXT", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Deadline = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CompletionTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ParentAssignmentID = table.Column<int>(type: "INTEGER", nullable: true),
                    AssignmentListID = table.Column<int>(type: "INTEGER", nullable: false),
                    Progress = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.AssignmentID);
                    table.ForeignKey(
                        name: "FK_Assignments_AssignmentLists_AssignmentListID",
                        column: x => x.AssignmentListID,
                        principalTable: "AssignmentLists",
                        principalColumn: "AssignmentListID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assignments_Users_AssignmentLeadID",
                        column: x => x.AssignmentLeadID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CommentText = table.Column<string>(type: "TEXT", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserID = table.Column<int>(type: "INTEGER", nullable: false),
                    AssignmentID = table.Column<int>(type: "INTEGER", nullable: false),
                    AttachmentPath = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentID);
                    table.ForeignKey(
                        name: "FK_Comments_Assignments_AssignmentID",
                        column: x => x.AssignmentID,
                        principalTable: "Assignments",
                        principalColumn: "AssignmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserAssignments",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "INTEGER", nullable: false),
                    AssignmentID = table.Column<int>(type: "INTEGER", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAssignments", x => new { x.UserID, x.AssignmentID, x.Type });
                    table.ForeignKey(
                        name: "FK_UserAssignments_Assignments_AssignmentID",
                        column: x => x.AssignmentID,
                        principalTable: "Assignments",
                        principalColumn: "AssignmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAssignments_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ProjectRoles",
                columns: new[] { "ProjectRoleID", "ProjectRoleName" },
                values: new object[,]
                {
                    { 1, "uloga1" },
                    { 2, "uloga2" }
                });

            migrationBuilder.InsertData(
                table: "TimeRegions",
                columns: new[] { "TimeRegionId", "TimeRegionName" },
                values: new object[,]
                {
                    { 1, "Central European Time (CET) - UTC+1" },
                    { 2, "Eastern European Time (EET) - UTC+2" },
                    { 3, "Central European Summer Time (CEST) - UTC+2" },
                    { 4, "Eastern European Summer Time (EEST) - UTC+3" },
                    { 5, "China Standard Time (CST) - UTC+8" },
                    { 6, "Australian Western Standard Time (AWST) - UTC+8" },
                    { 7, "Australian Central Standard Time (ACST) - UTC+9:30" },
                    { 8, "Australian Eastern Standard Time (AEST) - UTC+10" },
                    { 9, "Japan Standard Time (JST) - UTC+9" },
                    { 10, "India Standard Time (IST) - UTC+5:30" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserRoleID", "UserRoleName" },
                values: new object[,]
                {
                    { 1, "Administrator" },
                    { 2, "Manager" },
                    { 3, "Employee" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Activated", "DarkTheme", "DateOfBirth", "Email", "FirstName", "Language", "LastName", "Password", "PhoneNumber", "PictureURL", "PushEmailSettings", "PushNotificationSettings", "TimeRegionID", "Token", "UserRoleID", "Username" },
                values: new object[,]
                {
                    { 1, 1, 0, new DateTime(2003, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "marija.jolovic@pmf.kg.ac.rs", "Marija", "en", "Jolovic", "OU/rW8OrSTqlFl8pkyvgVQ==.DdorDWI2k+fRDAphu8YndoB1ARjeVK9Quh4+0PFT3v0=", "0542948241", "marija.jpg", 1, 1, 1, "be10cdce-a11e-4b21-9f63-f26078a44f8b", 2, "marija_jolovic" },
                    { 2, 1, 0, new DateTime(1999, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "novakovic214146@gmail.com", "Danilo", "en", "Novakovic", "uy1ogCfjplvkh+mBnJYCdg==.2w57Vv0YAV4SodDOaqIN/n6q18ygoYXjkAsMnpAlX6M=", "05421238244", "danilo.jpg", 1, 1, 1, "90545d9a-1763-4556-ab80-9db32d9eaacc", 2, "danilo_novakovic" },
                    { 3, 1, 0, new DateTime(2002, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "52-2021@pmf.kg.ac.rs", "Nikola", "en", "Lalic", "tPZkAMOE3tiMAs7G2lQUMA==.3PPQLqXOgVWc/Ib7FTjgi0ko5a8R++PBj0hK2+STNBM=", "06421238244", "nikola.jpg", 1, 1, 1, "7a09245c-609f-4ae0-9c1a-6fea7849a225", 2, "nikola_lalic" },
                    { 4, 1, 0, new DateTime(2001, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "63-2020@pmf.kg.ac.rs", "Aleksandar", "en", "Milutinovic", "lBbRnr0vaWRdVRiku+gwFw==.yVFDqX9DyvA0iksNIEG8m8QyhHsL2P+hXU6n+628NUc=", "05421238244", "aca.jpg", 1, 1, 1, "45c9379e-1ad5-4499-a05b-f0c93f1b81f8", 2, "aleksandar_milutinovic" },
                    { 5, 1, 0, new DateTime(2001, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "aleksandar2001milanovic@gmail.com", "Aleksandar", "en", "Milanovic", "1jUCtpf66nKEMgzcf1gcyQ==.EEI5LUSe01EGf6e/dFecbjpsiPGPRxSZAJ1rbZYB5zQ=", "05421238244", "coa.jpg", 1, 1, 1, "94135b9c-27ff-4c8c-b3b4-ccf1561e3329", 2, "aleksandar_milanovic" },
                    { 6, 1, 0, new DateTime(1999, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "87-2021@pmf.kg.ac.rs", "Djordje", "en", "Todorovic", "6+grcK7OxWuZuzzB87YWXw==.uPbx3ORqykkynYCxbPU29Q12PmmfKON8+ADbizFXwQ4=", "05421238244", "djordje.jpg", 1, 1, 1, "38553a26-fdda-4b55-ac9f-3f400b373da6", 2, "djordje_todorovic" },
                    { 7, 1, 0, new DateTime(1999, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "employee@pmf.kg.ac.rs", "Employko", "en", "Employkovic", "rYgvCEUXuXyuvmtvf+Tatw==.Jbou/lyJPp7+7Uw3p9mby1q0tuorWwj3LApbM0P4jx8=", "05421238244", "default_user.jpg", 1, 1, 1, "47c57962-0e4b-4dbc-843a-fc807270dadb", 3, "employee" },
                    { 8, 1, 0, new DateTime(2003, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@pmf.kg.ac.rs", "Adminko", "en", "Adminkovic", "zEj0f6k6RRxuFX7p3wVpTQ==.jTIIXXwUWJMWhnfDx3fnYRaOXqv0oy3Qh17rQ72zkDk=", "0542948241", "default_user.jpg", 1, 1, 1, "fb63801a-86be-4b61-ab94-a3cc50e6e7d5", 1, "admin" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectID", "Description", "EndDate", "ProjectLeaderID", "ProjectName", "StartDate", "Status", "UserID" },
                values: new object[,]
                {
                    { 1, "Development of a new mobile app for task management.", new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Project Alpha", new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "In Progress", null },
                    { 2, "Overhaul of marketing strategies and materials.", new DateTime(2024, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Marketing Campaign Revamp", new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "In Progress", null },
                    { 3, "Modernization and improvement of company website.", new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Website Redesign", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "In Progress", null },
                    { 4, "Launching a new product line into the market.", new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Product Launch - XYZ", new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "In Progress", null },
                    { 5, "Implementation of a comprehensive training program for staff development.", new DateTime(2024, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Employee Training Program", new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Planned", null },
                    { 6, "Upgrading company's IT infrastructure for improved efficiency and security.", new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Infrastructure Upgrade", new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Planned", null },
                    { 7, "Analyzing customer feedback to enhance product/service quality.", new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Customer Feedback Analysis", new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed", null },
                    { 8, "Research and entry into new geographical markets.", new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Expansion into New Markets", new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed", null },
                    { 9, "Implementation of eco-friendly practices within the organization.", new DateTime(2024, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Green Initiative Implementation", new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dismissed", null },
                    { 10, "Streamlining financial processes and systems for better efficiency.", new DateTime(2024, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Financial System Optimization", new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed", null }
                });

            migrationBuilder.InsertData(
                table: "AssignmentLists",
                columns: new[] { "AssignmentListID", "AssignmentListName", "Description", "ProjectID" },
                values: new object[,]
                {
                    { 1, "UI Development", "Tasks related to user interface development.", 1 },
                    { 2, "Backend Implementation", "Tasks related to backend logic implementation.", 1 },
                    { 3, "Marketing Material Update", "Tasks related to updating marketing materials.", 2 },
                    { 4, "Product Research", "Tasks related to conducting product research and surveys.", 4 },
                    { 5, "Customer Support", "Tasks related to customer support and inquiries.", 5 },
                    { 6, "Quality Assurance", "Tasks related to quality assurance and testing.", 5 },
                    { 7, "Content Creation", "Tasks related to creating content for the project.", 6 },
                    { 8, "Market Analysis", "Tasks related to analyzing the market trends.", 6 },
                    { 9, "Financial Planning", "Tasks related to financial planning and budgeting.", 7 },
                    { 10, "Supply Chain Management", "Tasks related to managing the supply chain.", 7 },
                    { 11, "Event Coordination", "Tasks related to coordinating project events.", 8 },
                    { 12, "Public Relations", "Tasks related to managing public relations for the project.", 8 },
                    { 13, "Legal Compliance", "Tasks related to ensuring legal compliance.", 9 },
                    { 14, "Training and Development", "Tasks related to employee training and development.", 9 },
                    { 15, "Mobile App Development", "Tasks related to developing a mobile application.", 10 },
                    { 16, "User Testing", "Tasks related to user testing and feedback collection.", 10 }
                });

            migrationBuilder.InsertData(
                table: "KanbanColumns",
                columns: new[] { "ProjectID", "Status", "UserID", "Index" },
                values: new object[,]
                {
                    { 1, "Completed", 1, 3 },
                    { 1, "Dismissed", 1, 4 },
                    { 1, "In Progress", 1, 2 },
                    { 1, "Planned", 1, 1 },
                    { 2, "Completed", 1, 3 },
                    { 2, "Dismissed", 1, 4 },
                    { 2, "In Progress", 1, 2 },
                    { 2, "Planned", 1, 1 },
                    { 3, "Completed", 1, 3 },
                    { 3, "Dismissed", 1, 4 },
                    { 3, "In Progress", 1, 2 },
                    { 3, "Planned", 1, 1 },
                    { 5, "Completed", 1, 3 },
                    { 5, "Dismissed", 1, 4 },
                    { 5, "In Progress", 1, 2 },
                    { 5, "Planned", 1, 1 },
                    { 7, "Completed", 1, 3 },
                    { 7, "Dismissed", 1, 4 },
                    { 7, "In Progress", 1, 2 },
                    { 7, "Planned", 1, 1 },
                    { 8, "Completed", 1, 3 },
                    { 8, "Dismissed", 1, 4 },
                    { 8, "In Progress", 1, 2 },
                    { 8, "Planned", 1, 1 },
                    { 9, "Completed", 1, 3 },
                    { 9, "Dismissed", 1, 4 },
                    { 9, "In Progress", 1, 2 },
                    { 9, "Planned", 1, 1 },
                    { 1, "Completed", 2, 3 },
                    { 1, "Dismissed", 2, 4 },
                    { 1, "In Progress", 2, 2 },
                    { 1, "Planned", 2, 1 },
                    { 2, "Completed", 2, 3 },
                    { 2, "Dismissed", 2, 4 },
                    { 2, "In Progress", 2, 2 },
                    { 2, "Planned", 2, 1 },
                    { 3, "Completed", 2, 3 },
                    { 3, "Dismissed", 2, 4 },
                    { 3, "In Progress", 2, 2 },
                    { 3, "Planned", 2, 1 },
                    { 5, "Completed", 2, 3 },
                    { 5, "Dismissed", 2, 4 },
                    { 5, "In Progress", 2, 2 },
                    { 5, "Planned", 2, 1 },
                    { 6, "Completed", 2, 3 },
                    { 6, "Dismissed", 2, 4 },
                    { 6, "In Progress", 2, 2 },
                    { 6, "Planned", 2, 1 },
                    { 8, "Completed", 2, 3 },
                    { 8, "Dismissed", 2, 4 },
                    { 8, "In Progress", 2, 2 },
                    { 8, "Planned", 2, 1 },
                    { 10, "Completed", 2, 3 },
                    { 10, "Dismissed", 2, 4 },
                    { 10, "In Progress", 2, 2 },
                    { 10, "Planned", 2, 1 },
                    { 1, "Completed", 3, 3 },
                    { 1, "Dismissed", 3, 4 },
                    { 1, "In Progress", 3, 2 },
                    { 1, "Planned", 3, 1 },
                    { 2, "Completed", 3, 3 },
                    { 2, "Dismissed", 3, 4 },
                    { 2, "In Progress", 3, 2 },
                    { 2, "Planned", 3, 1 },
                    { 4, "Completed", 3, 3 },
                    { 4, "Dismissed", 3, 4 },
                    { 4, "In Progress", 3, 2 },
                    { 4, "Planned", 3, 1 },
                    { 5, "Completed", 3, 3 },
                    { 5, "Dismissed", 3, 4 },
                    { 5, "In Progress", 3, 2 },
                    { 5, "Planned", 3, 1 },
                    { 6, "Completed", 3, 3 },
                    { 6, "Dismissed", 3, 4 },
                    { 6, "In Progress", 3, 2 },
                    { 6, "Planned", 3, 1 },
                    { 10, "Completed", 3, 3 },
                    { 10, "Dismissed", 3, 4 },
                    { 10, "In Progress", 3, 2 },
                    { 10, "Planned", 3, 1 },
                    { 2, "Completed", 4, 3 },
                    { 2, "Dismissed", 4, 4 },
                    { 2, "In Progress", 4, 2 },
                    { 2, "Planned", 4, 1 },
                    { 3, "Completed", 4, 3 },
                    { 3, "Dismissed", 4, 4 },
                    { 3, "In Progress", 4, 2 },
                    { 3, "Planned", 4, 1 },
                    { 4, "Completed", 4, 3 },
                    { 4, "Dismissed", 4, 4 },
                    { 4, "In Progress", 4, 2 },
                    { 4, "Planned", 4, 1 },
                    { 5, "Completed", 4, 3 },
                    { 5, "Dismissed", 4, 4 },
                    { 5, "In Progress", 4, 2 },
                    { 5, "Planned", 4, 1 },
                    { 6, "Completed", 4, 3 },
                    { 6, "Dismissed", 4, 4 },
                    { 6, "In Progress", 4, 2 },
                    { 6, "Planned", 4, 1 },
                    { 7, "Completed", 4, 3 },
                    { 7, "Dismissed", 4, 4 },
                    { 7, "In Progress", 4, 2 },
                    { 7, "Planned", 4, 1 },
                    { 9, "Completed", 4, 3 },
                    { 9, "Dismissed", 4, 4 },
                    { 9, "In Progress", 4, 2 },
                    { 9, "Planned", 4, 1 },
                    { 1, "Completed", 5, 3 },
                    { 1, "Dismissed", 5, 4 },
                    { 1, "In Progress", 5, 2 },
                    { 1, "Planned", 5, 1 },
                    { 3, "Completed", 5, 3 },
                    { 3, "Dismissed", 5, 4 },
                    { 3, "In Progress", 5, 2 },
                    { 3, "Planned", 5, 1 },
                    { 4, "Completed", 5, 3 },
                    { 4, "Dismissed", 5, 4 },
                    { 4, "In Progress", 5, 2 },
                    { 4, "Planned", 5, 1 },
                    { 7, "Completed", 5, 3 },
                    { 7, "Dismissed", 5, 4 },
                    { 7, "In Progress", 5, 2 },
                    { 7, "Planned", 5, 1 },
                    { 8, "Completed", 5, 3 },
                    { 8, "Dismissed", 5, 4 },
                    { 8, "In Progress", 5, 2 },
                    { 8, "Planned", 5, 1 },
                    { 9, "Completed", 5, 3 },
                    { 9, "Dismissed", 5, 4 },
                    { 9, "In Progress", 5, 2 },
                    { 9, "Planned", 5, 1 },
                    { 1, "Completed", 6, 3 },
                    { 1, "Dismissed", 6, 4 },
                    { 1, "In Progress", 6, 2 },
                    { 1, "Planned", 6, 1 },
                    { 2, "Completed", 6, 3 },
                    { 2, "Dismissed", 6, 4 },
                    { 2, "In Progress", 6, 2 },
                    { 2, "Planned", 6, 1 },
                    { 3, "Completed", 6, 3 },
                    { 3, "Dismissed", 6, 4 },
                    { 3, "In Progress", 6, 2 },
                    { 3, "Planned", 6, 1 },
                    { 4, "Completed", 6, 3 },
                    { 4, "Dismissed", 6, 4 },
                    { 4, "In Progress", 6, 2 },
                    { 4, "Planned", 6, 1 },
                    { 5, "Completed", 6, 3 },
                    { 5, "Dismissed", 6, 4 },
                    { 5, "In Progress", 6, 2 },
                    { 5, "Planned", 6, 1 },
                    { 7, "Completed", 6, 3 },
                    { 7, "Dismissed", 6, 4 },
                    { 7, "In Progress", 6, 2 },
                    { 7, "Planned", 6, 1 },
                    { 8, "Completed", 6, 3 },
                    { 8, "Dismissed", 6, 4 },
                    { 8, "In Progress", 6, 2 },
                    { 8, "Planned", 6, 1 },
                    { 9, "Completed", 6, 3 },
                    { 9, "Dismissed", 6, 4 },
                    { 9, "In Progress", 6, 2 },
                    { 9, "Planned", 6, 1 },
                    { 10, "Completed", 6, 3 },
                    { 10, "Dismissed", 6, 4 },
                    { 10, "In Progress", 6, 2 },
                    { 10, "Planned", 6, 1 }
                });

            migrationBuilder.InsertData(
                table: "UserProjects",
                columns: new[] { "ProjectID", "UserID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 5, 1 },
                    { 9, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 3, 2 },
                    { 4, 2 },
                    { 5, 2 },
                    { 6, 2 },
                    { 8, 2 },
                    { 10, 2 },
                    { 1, 3 },
                    { 2, 3 },
                    { 4, 3 },
                    { 5, 3 },
                    { 6, 3 },
                    { 10, 3 },
                    { 2, 4 },
                    { 3, 4 },
                    { 4, 4 },
                    { 5, 4 },
                    { 6, 4 },
                    { 7, 4 },
                    { 9, 4 },
                    { 1, 5 },
                    { 3, 5 },
                    { 4, 5 },
                    { 7, 5 },
                    { 8, 5 },
                    { 9, 5 },
                    { 1, 6 },
                    { 2, 6 },
                    { 3, 6 },
                    { 4, 6 },
                    { 5, 6 },
                    { 7, 6 },
                    { 8, 6 },
                    { 9, 6 },
                    { 10, 6 }
                });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "AssignmentID", "AssignmentLeadID", "AssignmentListID", "AssignmentName", "CompletionTime", "CreationDate", "Deadline", "Description", "ParentAssignmentID", "Priority", "Progress", "Status" },
                values: new object[,]
                {
                    { 1, 1, 1, "Develop User Interface", new DateTime(2024, 6, 10, 15, 55, 7, 856, DateTimeKind.Local).AddTicks(8068), new DateTime(2023, 4, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 24, 15, 55, 7, 856, DateTimeKind.Local).AddTicks(8020), "Design and implement UI for mobile app.", null, "Low", 0, "In Progress" },
                    { 2, 6, 2, "Implement Backend Logic", new DateTime(2024, 6, 10, 15, 55, 7, 856, DateTimeKind.Local).AddTicks(8080), new DateTime(2024, 4, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 1, 15, 55, 7, 856, DateTimeKind.Local).AddTicks(8077), "Develop backend functionalities for the mobile app.", 1, "Medium", 20, "Completed" },
                    { 3, 4, 3, "Update Marketing Material", null, new DateTime(2024, 2, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 20, 15, 55, 7, 856, DateTimeKind.Local).AddTicks(8084), "Revise existing marketing materials for the campaign.", null, "High", 0, "In Progress" },
                    { 4, 4, 3, "Optimize Website Performance", null, new DateTime(2024, 4, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 10, 15, 55, 7, 856, DateTimeKind.Local).AddTicks(8088), "Analyze and improve website loading speed and user experience.", null, "Low", 0, "Dismissed" },
                    { 5, 6, 4, "Conduct Product Survey", null, new DateTime(2024, 4, 8, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 17, 15, 55, 7, 856, DateTimeKind.Local).AddTicks(8092), "Gather feedback from potential customers regarding the new product.", null, "Medium", 0, "Planned" },
                    { 6, 2, 3, "Develop Marketing Strategy", null, new DateTime(2024, 3, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 25, 15, 55, 7, 856, DateTimeKind.Local).AddTicks(8096), "Create a comprehensive marketing strategy for the new campaign.", null, "High", 0, "In Progress" },
                    { 7, 2, 3, "Design Advertisements", null, new DateTime(2024, 4, 12, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 20, 15, 55, 7, 856, DateTimeKind.Local).AddTicks(8100), "Design eye-catching advertisements for the new campaign.", null, "Medium", 0, "Planned" },
                    { 8, 4, 3, "Analyze Website Traffic", null, new DateTime(2024, 2, 26, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 15, 55, 7, 856, DateTimeKind.Local).AddTicks(8103), "Analyze website traffic data to identify trends and insights.", null, "Medium", 0, "In Progress" },
                    { 9, 2, 4, "Prepare Training Material", null, new DateTime(2024, 4, 16, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 20, 15, 55, 7, 856, DateTimeKind.Local).AddTicks(8107), "Prepare training material for the upcoming employee training program.", null, "Low", 0, "Planned" },
                    { 10, 3, 4, "Conduct Staff Survey", null, new DateTime(2024, 4, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 17, 15, 55, 7, 856, DateTimeKind.Local).AddTicks(8112), "Conduct a survey to gather feedback from employees regarding training needs.", null, "Low", 0, "Planned" },
                    { 11, 2, 1, "Update Project Documentation", new DateTime(2024, 3, 25, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 20, 15, 55, 7, 856, DateTimeKind.Local).AddTicks(8116), "Update project documentation with the latest changes and progress.", 1, "Medium", 0, "In Progress" },
                    { 12, 5, 2, "Test New Feature", null, new DateTime(2024, 6, 10, 15, 55, 7, 856, DateTimeKind.Local).AddTicks(8122), new DateTime(2024, 6, 17, 15, 55, 7, 856, DateTimeKind.Local).AddTicks(8124), "Test the functionality of the new feature on the mobile app.", null, "High", 0, "In Progress" },
                    { 13, 2, 3, "Review Marketing Campaign Results", null, new DateTime(2024, 6, 10, 15, 55, 7, 856, DateTimeKind.Local).AddTicks(8127), new DateTime(2024, 6, 25, 15, 55, 7, 856, DateTimeKind.Local).AddTicks(8129), "Review the results of the marketing campaign and make necessary adjustments.", null, "Medium", 0, "Planned" },
                    { 14, 5, 4, "Conduct Product Demo", null, new DateTime(2024, 6, 10, 15, 55, 7, 856, DateTimeKind.Local).AddTicks(8132), new DateTime(2024, 6, 20, 15, 55, 7, 856, DateTimeKind.Local).AddTicks(8134), "Conduct a live demonstration of the new product to potential clients.", null, "High", 0, "Planned" },
                    { 17, 1, 5, "Setup Helpdesk System", null, new DateTime(2024, 4, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 24, 15, 55, 7, 856, DateTimeKind.Local).AddTicks(8138), "Implement a helpdesk system for customer support.", null, "Medium", 0, "Planned" },
                    { 18, 3, 13, "Train Customer Support Team", null, new DateTime(2024, 4, 5, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 1, 15, 55, 7, 856, DateTimeKind.Local).AddTicks(8142), "Provide training sessions for the customer support team.", null, "High", 0, "Planned" },
                    { 19, 1, 14, "Create Support Documentation", null, new DateTime(2024, 4, 8, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 20, 15, 55, 7, 856, DateTimeKind.Local).AddTicks(8145), "Prepare documentation for common customer queries.", null, "Low", 0, "In Progress" },
                    { 21, 5, 6, "Perform System Testing", null, new DateTime(2024, 4, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 24, 15, 55, 7, 856, DateTimeKind.Local).AddTicks(8149), "Perform rigorous testing of the system for quality assurance.", null, "High", 0, "Planned" },
                    { 22, 1, 6, "Implement Security Measures", null, new DateTime(2024, 4, 6, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 1, 15, 55, 7, 856, DateTimeKind.Local).AddTicks(8153), "Implement additional security measures for the system.", null, "Medium", 0, "In Progress" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentID", "AssignmentID", "AttachmentPath", "CommentText", "CreationDate", "UserID" },
                values: new object[,]
                {
                    { 1, 1, null, "Comment 1", new DateTime(2024, 6, 10, 15, 55, 7, 856, DateTimeKind.Local).AddTicks(8208), 1 },
                    { 2, 1, null, "Another comment", new DateTime(2024, 6, 10, 15, 55, 7, 856, DateTimeKind.Local).AddTicks(8213), 2 },
                    { 3, 2, null, "Feedback received", new DateTime(2024, 6, 10, 15, 55, 7, 856, DateTimeKind.Local).AddTicks(8216), 3 },
                    { 5, 3, null, "Clarification needed", new DateTime(2024, 6, 10, 15, 55, 7, 856, DateTimeKind.Local).AddTicks(8219), 4 },
                    { 8, 4, null, "Issue resolved", new DateTime(2024, 6, 10, 15, 55, 7, 856, DateTimeKind.Local).AddTicks(8221), 4 },
                    { 9, 5, null, "Progress update", new DateTime(2024, 6, 10, 15, 55, 7, 856, DateTimeKind.Local).AddTicks(8224), 4 },
                    { 11, 6, null, "Request for information", new DateTime(2024, 6, 10, 15, 55, 7, 856, DateTimeKind.Local).AddTicks(8227), 2 },
                    { 13, 7, null, "Error detected", new DateTime(2024, 6, 10, 15, 55, 7, 856, DateTimeKind.Local).AddTicks(8229), 2 },
                    { 14, 7, null, "Resource allocation request", new DateTime(2024, 6, 10, 15, 55, 7, 856, DateTimeKind.Local).AddTicks(8232), 2 },
                    { 15, 8, null, "Revision requested", new DateTime(2024, 6, 10, 15, 55, 7, 856, DateTimeKind.Local).AddTicks(8234), 4 },
                    { 16, 8, null, "Update on project status", new DateTime(2024, 6, 10, 15, 55, 7, 856, DateTimeKind.Local).AddTicks(8237), 4 },
                    { 17, 9, null, "Training material uploaded", new DateTime(2024, 6, 10, 15, 55, 7, 856, DateTimeKind.Local).AddTicks(8240), 2 },
                    { 18, 9, null, "Bug fix in progress", new DateTime(2024, 6, 10, 15, 55, 7, 856, DateTimeKind.Local).AddTicks(8242), 2 },
                    { 19, 10, null, "Meeting scheduled", new DateTime(2024, 6, 10, 15, 55, 7, 856, DateTimeKind.Local).AddTicks(8245), 3 },
                    { 20, 10, null, "Documentation updated", new DateTime(2024, 6, 10, 15, 55, 7, 856, DateTimeKind.Local).AddTicks(8247), 3 },
                    { 21, 11, null, "Budget approval pending", new DateTime(2024, 6, 10, 15, 55, 7, 856, DateTimeKind.Local).AddTicks(8250), 2 }
                });

            migrationBuilder.InsertData(
                table: "UserAssignments",
                columns: new[] { "AssignmentID", "Type", "UserID" },
                values: new object[,]
                {
                    { 17, 0, 1 },
                    { 18, 0, 1 },
                    { 19, 0, 1 },
                    { 21, 0, 1 },
                    { 22, 0, 1 },
                    { 1, 0, 2 },
                    { 2, 0, 2 },
                    { 4, 0, 2 },
                    { 22, 0, 2 },
                    { 1, 0, 3 },
                    { 2, 0, 3 },
                    { 5, 0, 3 },
                    { 3, 0, 4 },
                    { 5, 0, 4 },
                    { 17, 0, 4 },
                    { 18, 0, 4 },
                    { 21, 0, 4 },
                    { 22, 0, 4 },
                    { 18, 0, 5 },
                    { 19, 0, 5 },
                    { 3, 0, 6 },
                    { 4, 0, 6 },
                    { 17, 0, 6 },
                    { 21, 0, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentLists_ProjectID",
                table: "AssignmentLists",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_AssignmentLeadID",
                table: "Assignments",
                column: "AssignmentLeadID");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_AssignmentListID",
                table: "Assignments",
                column: "AssignmentListID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AssignmentID",
                table: "Comments",
                column: "AssignmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserID",
                table: "Comments",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_KanbanColumns_ProjectID",
                table: "KanbanColumns",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserID",
                table: "Notifications",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectLeaderID",
                table: "Projects",
                column: "ProjectLeaderID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UserID",
                table: "Projects",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserAssignments_AssignmentID",
                table: "UserAssignments",
                column: "AssignmentID");

            migrationBuilder.CreateIndex(
                name: "IX_UserProjects_ProjectID",
                table: "UserProjects",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_TimeRegionID",
                table: "Users",
                column: "TimeRegionID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserRoleID",
                table: "Users",
                column: "UserRoleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "KanbanColumns");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "ProjectRoles");

            migrationBuilder.DropTable(
                name: "TimeEntries");

            migrationBuilder.DropTable(
                name: "UserAssignments");

            migrationBuilder.DropTable(
                name: "UserProjects");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "AssignmentLists");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "TimeRegions");

            migrationBuilder.DropTable(
                name: "UserRoles");
        }
    }
}
