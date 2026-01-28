using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "assets",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    asset_name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    asset_code = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    status = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false, defaultValue: "Available")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assets", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Benefits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Benefits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "leave_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    max_days = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_leave_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "positions",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    base_salary = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    department_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_positions", x => x.id);
                    table.ForeignKey(
                        name: "FK_positions_departments_department_id",
                        column: x => x.department_id,
                        principalTable: "departments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    employee_code = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    first_name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    last_name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    gender = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    dob = table.Column<DateTime>(type: "TEXT", nullable: true),
                    email = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    phone = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    address = table.Column<string>(type: "TEXT", nullable: false),
                    hire_date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    status = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false, defaultValue: "Active"),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    department_id = table.Column<int>(type: "INTEGER", nullable: true),
                    position_id = table.Column<int>(type: "INTEGER", nullable: true),
                    supervisor_id = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.id);
                    table.ForeignKey(
                        name: "FK_employees_departments_department_id",
                        column: x => x.department_id,
                        principalTable: "departments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_employees_employees_supervisor_id",
                        column: x => x.supervisor_id,
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_employees_positions_position_id",
                        column: x => x.position_id,
                        principalTable: "positions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "attendance",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    attendance_date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    check_in = table.Column<TimeSpan>(type: "TEXT", nullable: true),
                    check_out = table.Column<TimeSpan>(type: "TEXT", nullable: true),
                    status = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    employee_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attendance", x => x.id);
                    table.ForeignKey(
                        name: "FK_attendance_employees_employee_id",
                        column: x => x.employee_id,
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "employee_assets",
                columns: table => new
                {
                    employee_id = table.Column<int>(type: "INTEGER", nullable: false),
                    asset_id = table.Column<int>(type: "INTEGER", nullable: false),
                    assigned_date = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_DATE"),
                    return_date = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee_assets", x => new { x.employee_id, x.asset_id });
                    table.ForeignKey(
                        name: "FK_employee_assets_assets_asset_id",
                        column: x => x.asset_id,
                        principalTable: "assets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_employee_assets_employees_employee_id",
                        column: x => x.employee_id,
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "employee_benefits",
                columns: table => new
                {
                    employee_id = table.Column<int>(type: "INTEGER", nullable: false),
                    benefit_id = table.Column<int>(type: "INTEGER", nullable: false),
                    assigned_date = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_DATE"),
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee_benefits", x => new { x.employee_id, x.benefit_id });
                    table.ForeignKey(
                        name: "FK_employee_benefits_Benefits_benefit_id",
                        column: x => x.benefit_id,
                        principalTable: "Benefits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_employee_benefits_employees_employee_id",
                        column: x => x.employee_id,
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "leaves",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    start_date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    end_date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    reason = table.Column<string>(type: "TEXT", nullable: false),
                    status = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false, defaultValue: "Pending"),
                    applied_at = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    employee_id = table.Column<int>(type: "INTEGER", nullable: false),
                    leave_type_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_leaves", x => x.id);
                    table.ForeignKey(
                        name: "FK_leaves_employees_employee_id",
                        column: x => x.employee_id,
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_leaves_leave_types_leave_type_id",
                        column: x => x.leave_type_id,
                        principalTable: "leave_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "payroll",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    salary_month = table.Column<string>(type: "TEXT", maxLength: 7, nullable: false),
                    base_salary = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: false),
                    allowance = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: false, defaultValue: 0m),
                    deduction = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: false, defaultValue: 0m),
                    net_salary = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: false, computedColumnSql: "base_salary + allowance - deduction", stored: true),
                    paid_date = table.Column<DateTime>(type: "TEXT", nullable: true),
                    employee_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payroll", x => x.id);
                    table.ForeignKey(
                        name: "FK_payroll_employees_employee_id",
                        column: x => x.employee_id,
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "performance_reviews",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    review_date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    rating = table.Column<int>(type: "INTEGER", nullable: false),
                    comments = table.Column<string>(type: "TEXT", nullable: false),
                    employee_id = table.Column<int>(type: "INTEGER", nullable: false),
                    reviewer_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_performance_reviews", x => x.id);
                    table.ForeignKey(
                        name: "FK_performance_reviews_employees_employee_id",
                        column: x => x.employee_id,
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_performance_reviews_employees_reviewer_id",
                        column: x => x.reviewer_id,
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_assets_asset_code",
                table: "assets",
                column: "asset_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_assets_status",
                table: "assets",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "IX_attendance_attendance_date",
                table: "attendance",
                column: "attendance_date");

            migrationBuilder.CreateIndex(
                name: "IX_attendance_employee_id",
                table: "attendance",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_attendance_employee_id_attendance_date",
                table: "attendance",
                columns: new[] { "employee_id", "attendance_date" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_attendance_status",
                table: "attendance",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "IX_departments_name",
                table: "departments",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_employee_assets_asset_id",
                table: "employee_assets",
                column: "asset_id");

            migrationBuilder.CreateIndex(
                name: "IX_employee_assets_assigned_date",
                table: "employee_assets",
                column: "assigned_date");

            migrationBuilder.CreateIndex(
                name: "IX_employee_assets_employee_id",
                table: "employee_assets",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_employee_assets_return_date",
                table: "employee_assets",
                column: "return_date");

            migrationBuilder.CreateIndex(
                name: "IX_employee_benefits_assigned_date",
                table: "employee_benefits",
                column: "assigned_date");

            migrationBuilder.CreateIndex(
                name: "IX_employee_benefits_benefit_id",
                table: "employee_benefits",
                column: "benefit_id");

            migrationBuilder.CreateIndex(
                name: "IX_employee_benefits_employee_id",
                table: "employee_benefits",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_employees_department_id",
                table: "employees",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_employees_email",
                table: "employees",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_employees_employee_code",
                table: "employees",
                column: "employee_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_employees_first_name_last_name",
                table: "employees",
                columns: new[] { "first_name", "last_name" });

            migrationBuilder.CreateIndex(
                name: "IX_employees_position_id",
                table: "employees",
                column: "position_id");

            migrationBuilder.CreateIndex(
                name: "IX_employees_status",
                table: "employees",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "IX_employees_supervisor_id",
                table: "employees",
                column: "supervisor_id");

            migrationBuilder.CreateIndex(
                name: "IX_leave_types_name",
                table: "leave_types",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_leaves_employee_id",
                table: "leaves",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_leaves_end_date",
                table: "leaves",
                column: "end_date");

            migrationBuilder.CreateIndex(
                name: "IX_leaves_leave_type_id",
                table: "leaves",
                column: "leave_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_leaves_start_date",
                table: "leaves",
                column: "start_date");

            migrationBuilder.CreateIndex(
                name: "IX_leaves_status",
                table: "leaves",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "IX_payroll_employee_id",
                table: "payroll",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_payroll_employee_id_salary_month",
                table: "payroll",
                columns: new[] { "employee_id", "salary_month" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_payroll_paid_date",
                table: "payroll",
                column: "paid_date");

            migrationBuilder.CreateIndex(
                name: "IX_payroll_salary_month",
                table: "payroll",
                column: "salary_month");

            migrationBuilder.CreateIndex(
                name: "IX_performance_reviews_employee_id",
                table: "performance_reviews",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_performance_reviews_rating",
                table: "performance_reviews",
                column: "rating");

            migrationBuilder.CreateIndex(
                name: "IX_performance_reviews_review_date",
                table: "performance_reviews",
                column: "review_date");

            migrationBuilder.CreateIndex(
                name: "IX_performance_reviews_reviewer_id",
                table: "performance_reviews",
                column: "reviewer_id");

            migrationBuilder.CreateIndex(
                name: "IX_positions_department_id",
                table: "positions",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_positions_title",
                table: "positions",
                column: "title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "attendance");

            migrationBuilder.DropTable(
                name: "employee_assets");

            migrationBuilder.DropTable(
                name: "employee_benefits");

            migrationBuilder.DropTable(
                name: "leaves");

            migrationBuilder.DropTable(
                name: "payroll");

            migrationBuilder.DropTable(
                name: "performance_reviews");

            migrationBuilder.DropTable(
                name: "assets");

            migrationBuilder.DropTable(
                name: "Benefits");

            migrationBuilder.DropTable(
                name: "leave_types");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "positions");

            migrationBuilder.DropTable(
                name: "departments");
        }
    }
}
