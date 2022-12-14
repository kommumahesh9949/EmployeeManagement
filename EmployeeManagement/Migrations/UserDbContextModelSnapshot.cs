// <auto-generated />
using System;
using EmployeeManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmployeeManagement.Migrations
{
    [DbContext(typeof(UserDbContext))]
    partial class UserDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmployeeManagement.Models.EmployeeModel.Designation", b =>
                {
                    b.Property<int>("Sno")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DepartmentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DesignationName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Sno");

                    b.ToTable("designations");
                });

            modelBuilder.Entity("EmployeeManagement.Models.EmployeeModel.Employee", b =>
                {
                    b.Property<int>("SerialNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MailId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.HasKey("SerialNo");

                    b.ToTable("employees");
                });

            modelBuilder.Entity("EmployeeManagement.Models.EmployeeModel.LeaveModel", b =>
                {
                    b.Property<int>("Sno")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LeaveType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("When")
                        .HasColumnType("datetime2");

                    b.HasKey("Sno");

                    b.ToTable("leaveModels");
                });

            modelBuilder.Entity("EmployeeManagement.Models.EmployeeModel.Payment", b =>
                {
                    b.Property<int>("Sno")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccountType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IfscCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Sno");

                    b.ToTable("payments");
                });

            modelBuilder.Entity("EmployeeManagement.Models.EmployeeModel.WorkingHour", b =>
                {
                    b.Property<int>("Sno")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyMonthlyHours")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeMonthlyHours")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Sno");

                    b.ToTable("workingHours");
                });

            modelBuilder.Entity("EmployeeManagement.Models.UserModel.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("users");
                });
#pragma warning restore 612, 618
        }
    }
}
