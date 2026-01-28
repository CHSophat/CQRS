using System;
using HRManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

[DbContext(typeof(AppDbContext))]
partial class AppDbContextModelSnapshot : ModelSnapshot
{
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
        modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

        modelBuilder.Entity("Department", b =>
        {
            b.Property<int>("Id")
                .ValueGeneratedOnAdd();

            b.Property<DateTime>("CreatedAt");

            b.Property<string>("Description");

            b.Property<string>("Name")
                .IsRequired()
                .HasMaxLength(100);

            b.HasKey("Id");

            b.ToTable("Departments");
        });

        modelBuilder.Entity("Position", b =>
        {
            b.Property<int>("Id")
                .ValueGeneratedOnAdd();

            b.Property<decimal?>("BaseSalary")
                .HasColumnType("decimal(10,2)");

            b.Property<DateTime>("CreatedAt");

            b.Property<int?>("DepartmentId");

            b.Property<string>("Title")
                .IsRequired()
                .HasMaxLength(100);

            b.HasKey("Id");

            b.HasIndex("DepartmentId");

            b.ToTable("Positions");
        });

        modelBuilder.Entity("Employee", b =>
        {
            b.Property<int>("Id")
                .ValueGeneratedOnAdd();

            b.Property<string>("Address");

            b.Property<DateTime>("CreatedAt");

            b.Property<int?>("DepartmentId");

            b.Property<DateTime?>("Dob");

            b.Property<string>("Email")
                .HasMaxLength(150);

            b.Property<string>("EmployeeCode")
                .IsRequired()
                .HasMaxLength(20);

            b.Property<string>("FirstName")
                .HasMaxLength(100);

            b.Property<string>("Gender")
                .HasMaxLength(10);

            b.Property<DateTime?>("HireDate");

            b.Property<string>("LastName")
                .HasMaxLength(100);

            b.Property<string>("Phone")
                .HasMaxLength(20);

            b.Property<int?>("PositionId");

            b.Property<int?>("SupervisorId");

            b.Property<string>("Status")
                .HasMaxLength(20);

            b.HasKey("Id");

            b.HasIndex("DepartmentId");
            b.HasIndex("PositionId");
            b.HasIndex("SupervisorId");
            b.HasIndex("Email").IsUnique();
            b.HasIndex("EmployeeCode").IsUnique();

            b.ToTable("Employees");
        });

        modelBuilder.Entity("Attendance", b =>
        {
            b.Property<int>("Id")
                .ValueGeneratedOnAdd();

            b.Property<DateTime>("AttendanceDate");

            b.Property<TimeSpan?>("CheckIn");

            b.Property<TimeSpan?>("CheckOut");

            b.Property<DateTime>("CreatedAt");

            b.Property<int>("EmployeeId");

            b.Property<string>("Status")
                .HasMaxLength(20);

            b.HasKey("Id");

            b.HasIndex("EmployeeId");

            b.ToTable("Attendance");
        });

        modelBuilder.Entity("LeaveType", b =>
        {
            b.Property<int>("Id")
                .ValueGeneratedOnAdd();

            b.Property<int>("MaxDays");

            b.Property<string>("Name")
                .HasMaxLength(50);

            b.HasKey("Id");

            b.ToTable("LeaveTypes");
        });

        modelBuilder.Entity("Leave", b =>
        {
            b.Property<int>("Id")
                .ValueGeneratedOnAdd();

            b.Property<DateTime>("AppliedAt");

            b.Property<DateTime>("EndDate");

            b.Property<int>("EmployeeId");

            b.Property<int>("LeaveTypeId");

            b.Property<string>("Reason");

            b.Property<DateTime>("StartDate");

            b.Property<string>("Status")
                .HasMaxLength(20);

            b.HasKey("Id");

            b.HasIndex("EmployeeId");
            b.HasIndex("LeaveTypeId");

            b.ToTable("Leaves");
        });

        modelBuilder.Entity("Payroll", b =>
        {
            b.Property<int>("Id")
                .ValueGeneratedOnAdd();

            b.Property<decimal>("Allowance")
                .HasColumnType("decimal(10,2)");

            b.Property<decimal>("BaseSalary")
                .HasColumnType("decimal(10,2)");

            b.Property<decimal>("Deduction")
                .HasColumnType("decimal(10,2)");

            b.Property<int>("EmployeeId");

            b.Property<decimal>("NetSalary")
                .HasColumnType("decimal(10,2)");

            b.Property<DateTime?>("PaidDate");

            b.Property<string>("SalaryMonth")
                .HasMaxLength(7);

            b.HasKey("Id");

            b.HasIndex("EmployeeId");

            b.ToTable("Payroll");
        });

        modelBuilder.Entity("EmployeeBenefit", b =>
        {
            b.Property<int>("EmployeeId");
            b.Property<int>("BenefitId");
            b.Property<DateTime>("AssignedDate");

            b.HasKey("EmployeeId", "BenefitId");

            b.ToTable("EmployeeBenefits");
        });

        modelBuilder.Entity("EmployeeAsset", b =>
        {
            b.Property<int>("EmployeeId");
            b.Property<int>("AssetId");
            b.Property<DateTime>("AssignedDate");
            b.Property<DateTime?>("ReturnDate");

            b.HasKey("EmployeeId", "AssetId");

            b.ToTable("EmployeeAssets");
        });

        // ---------- RELATIONSHIPS ----------
        modelBuilder.Entity("Position")
            .HasOne("Department")
            .WithMany("Positions")
            .HasForeignKey("DepartmentId");

        modelBuilder.Entity("Employee")
            .HasOne("Department")
            .WithMany("Employees")
            .HasForeignKey("DepartmentId");

        modelBuilder.Entity("Employee")
            .HasOne("Position")
            .WithMany("Employees")
            .HasForeignKey("PositionId");

        modelBuilder.Entity("Employee")
            .HasOne("Employee")
            .WithMany("Subordinates")
            .HasForeignKey("SupervisorId")
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity("Attendance")
            .HasOne("Employee")
            .WithMany("Attendances")
            .HasForeignKey("EmployeeId");

        modelBuilder.Entity("Leave")
            .HasOne("Employee")
            .WithMany("Leaves")
            .HasForeignKey("EmployeeId");

        modelBuilder.Entity("Leave")
            .HasOne("LeaveType")
            .WithMany("Leaves")
            .HasForeignKey("LeaveTypeId");
    }
}
