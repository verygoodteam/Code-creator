using System;
using System.Collections.Generic;
using HR.Hospital.Model.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HR.Hospital.Model
{
    public partial class hospitaldbContext : DbContext
    {
        public hospitaldbContext()
        {
        }

        public hospitaldbContext(DbContextOptions<hospitaldbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// 执行查询院区的sql语句
        /// </summary>
        public DbQuery<AreaDto> QueryAreaDto { get; set; }

        /// <summary>
        /// 执行两表联查
        /// </summary>
        public DbQuery<AreaRoomDto> QueryAreaRoomDto { get; set; }

        /// <summary>
        /// 获取科室列表信息
        /// </summary>
        public virtual DbSet<Administrative> Administrative { get; set; }

        /// <summary>
        /// 获取院区列表信息
        /// </summary>
        public virtual DbSet<Area> Area { get; set; }

        /// <summary>
        /// 获取临床用户列表信息
        /// </summary>
        public virtual DbSet<Clinicuser> Clinicuser { get; set; }

        /// <summary>
        /// 获取职能信息
        /// </summary>
        public virtual DbSet<Hierarchy> Hierarchy { get; set; }

        /// <summary>
        /// 获取手术间用户信息
        /// </summary>
        public virtual DbSet<Ooperationuser> Ooperationuser { get; set; }

        /// <summary>
        /// 获取手术间信息
        /// </summary>
        public virtual DbSet<OperationRoom> Operationroom { get; set; }

        /// <summary>
        /// 获取手术类别信息
        /// </summary>
        public virtual DbSet<Operations> Operations { get; set; }

        /// <summary>
        /// 获取手术排班信息
        /// </summary>
        public virtual DbSet<Operationscheduling> Operationscheduling { get; set; }

        /// <summary>
        /// 获取权限信息
        /// </summary>
        public virtual DbSet<Permission> Permission { get; set; }

        /// <summary>
        /// 获取职务信息
        /// </summary>
        public virtual DbSet<Position> Position { get; set; }

        /// <summary>
        /// 获取职称信息
        /// </summary>
        public virtual DbSet<Professional> Professional { get; set; }

        /// <summary>
        /// 获取专业组信息
        /// </summary>
        public virtual DbSet<Professionalgroup> Professionalgroup { get; set; }

        /// <summary>
        /// 获取角色信息
        /// </summary>
        public virtual DbSet<Role> Role { get; set; }

        /// <summary>
        /// 获取角色权限信息
        /// </summary>
        public virtual DbSet<RolePermission> RolePermission { get; set; }

        /// <summary>
        /// 获取规则设置信息
        /// </summary>
        public virtual DbSet<Rulesettings> Rulesettings { get; set; }

        /// <summary>
        /// 获取班次信息
        /// </summary>
        public virtual DbSet<Shiftssetting> Shiftssetting { get; set; }

        /// <summary>
        /// 获取时间信息
        /// </summary>
        public virtual DbSet<Times> Times { get; set; }

        /// <summary>
        /// 获取用户角色信息
        /// </summary>
        public virtual DbSet<UserRole> UserRole { get; set; }


        /// <summary>
        /// 获取审批活动表信息
        /// </summary>
        public virtual DbSet<ActivityTable> Activity { get; set; }

        /// <summary>
        /// 获取审批类型信息
        /// </summary>
        public virtual DbSet<ApprovalType> ApprovalType { get; set; }

        /// <summary>
        /// 获取审批级别信息
        /// </summary>
        public virtual DbSet<UserLevel> UserLevel { get; set; }

        /// <summary>
        /// 排班表
        /// </summary>
        public virtual DbSet<Scheduling> Schedulings { get; set; }

        public virtual DbSet<ApprovalConfiguration> ApprovalConfiguration { get; set; }


        
        public virtual DbSet<AttendanceDetail> AttendanceDetail { get; set; }
        public virtual DbSet<AttendanceSummary> AttendanceSummary { get; set; }
        public virtual DbSet<SolitaireSet> SolitaireSet { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseMySql("Server=127.0.0.1;Database=hospitaldb;Uid=root;Pwd=2278866266");
                optionsBuilder.UseMySql("Server=169.254.224.180;Database=hospitaldb;Uid=root;Pwd=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrative>(entity =>
            {
                entity.ToTable("administrative");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.AdministrativeName).HasColumnType("varchar(50)");

                entity.Property(e => e.AdministrativeRemark).HasColumnType("varchar(100)");

                entity.Property(e => e.Isoperation).HasColumnType("int(11)");
            });

            //添加配置表中字段信息
            modelBuilder.Entity<ApprovalConfiguration>(entity =>
            {
                entity.ToTable("approvalConfiguration");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ActivityId).HasColumnType("int(11)");

                entity.Property(e => e.UserLevelId).HasColumnType("int(11)");

                entity.Property(e => e.DownId).HasColumnType("int(11)");

                entity.Property(e => e.Start).HasColumnType("varchar(255)");

                entity.Property(e => e.SortId).HasColumnType("int(11)");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnType("int(11)");

            });

            //自己添加的审批活动表
            modelBuilder.Entity<ActivityTable>(entity =>
            {
                entity.ToTable("ActivityTable");

                entity.Property(e => e.Id).HasColumnType("int(12)");

                entity.Property(e => e.ActivityName).HasColumnType("varchar(255)");

            });

            //自己添加的审批类型表
            modelBuilder.Entity<ApprovalType>(entity =>
            {
                entity.ToTable("approvalType");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.TypeName).HasColumnType("varchar(100)");

            });

            //审批级别表
            modelBuilder.Entity<UserLevel>(entity =>
            {
                entity.ToTable("userLevel");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.LevelName).HasColumnType("varchar(66)");

                entity.Property(e => e.UserId).HasColumnType("int(11)");

                entity.Property(e => e.RoleId).HasColumnType("int(11)");


            });


            modelBuilder.Entity<Area>(entity =>
            {
                entity.ToTable("area");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.AreaName).HasColumnType("varchar(50)");

                entity.Property(e => e.AreaProperty).HasColumnType("int(11)");

                entity.Property(e => e.AreaRemark).HasColumnType("varchar(100)");

                entity.Property(e => e.Isnable).HasColumnType("int(11)");

                entity.Property(e => e.OperatingNum).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Clinicuser>(entity =>
            {
                entity.ToTable("clinicuser");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Aadministrativeid).HasColumnType("int(11)");

                entity.Property(e => e.ClinicUserName).HasColumnType("varchar(50)");

                entity.Property(e => e.ClinicUserRemark).HasColumnType("varchar(100)");

                entity.Property(e => e.Jobnumber).HasColumnType("varchar(50)");

                entity.Property(e => e.Sex).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Hierarchy>(entity =>
            {
                entity.ToTable("hierarchy");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.HierarchyName).HasColumnType("varchar(10)");
            });

            modelBuilder.Entity<Ooperationuser>(entity =>
            {
                entity.ToTable("ooperationuser");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Account).HasColumnType("varchar(50)");

                entity.Property(e => e.Annualdays).HasColumnType("int(11)");

                entity.Property(e => e.Enrollmentdate).HasColumnType("datetime");

                entity.Property(e => e.Grade).HasColumnType("varchar(50)");

                entity.Property(e => e.HierarchyId).HasColumnType("int(11)");

                entity.Property(e => e.Isarrange).HasColumnType("int(11)");

                entity.Property(e => e.Jobnumber).HasColumnType("varchar(50)");

                entity.Property(e => e.OoperationUserName).HasColumnType("varchar(50)");

                entity.Property(e => e.OoperationUserRemark).HasColumnType("varchar(100)");

                entity.Property(e => e.Phone).HasColumnType("varchar(11)");

                entity.Property(e => e.PositionId).HasColumnType("int(11)");

                entity.Property(e => e.ProfessionalId)
                    .HasColumnName("professionalId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Pwd).HasColumnType("varchar(50)");

                entity.Property(e => e.Roleid).HasColumnType("int(11)");

                entity.Property(e => e.Sex).HasColumnType("int(11)");

                entity.Property(e => e.Simplename).HasColumnType("varchar(50)");

                entity.Property(e => e.Userid).HasColumnType("int(11)");

                entity.Property(e => e.Workage).HasColumnType("int(11)");
            });

            modelBuilder.Entity<OperationRoom>(entity =>
            {
                entity.ToTable("operationroom");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.AreaId).HasColumnType("int(11)");

                entity.Property(e => e.OperationName).HasColumnType("varchar(50)");

                entity.Property(e => e.OperationRemark).HasColumnType("varchar(100)");

                entity.Property(e => e.EnableOperation).HasColumnType("int(3)");
            });

            modelBuilder.Entity<Operations>(entity =>
            {
                entity.ToTable("operations");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.DepartmentId).HasColumnType("int(11)");

                entity.Property(e => e.OperationCreateTime).HasColumnType("char(10)");

                entity.Property(e => e.OperationName).HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Operationscheduling>(entity =>
            {
                entity.ToTable("operationscheduling");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.AnesthesiologistId).HasColumnType("int(11)");

                entity.Property(e => e.ApparatusUserId).HasColumnType("int(11)");

                entity.Property(e => e.InpatientArea).HasColumnType("int(11)");

                entity.Property(e => e.OperatingRoomId).HasColumnType("int(11)");

                entity.Property(e => e.OperationId).HasColumnType("int(11)");

                entity.Property(e => e.OperationRemark).HasColumnType("varchar(200)");

                entity.Property(e => e.OperationUserId).HasColumnType("int(11)");

                entity.Property(e => e.PatientId).HasColumnType("int(11)");

                entity.Property(e => e.TableNumber).HasColumnType("int(11)");

                entity.Property(e => e.TourUserId).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.ToTable("permission");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Createtime).HasColumnType("datetime");

                entity.Property(e => e.Isnable).HasColumnType("int(11)");

                entity.Property(e => e.PermissionsName).HasColumnType("varchar(50)");

                entity.Property(e => e.Pid).HasColumnType("int(11)");

                entity.Property(e => e.Url).HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("position");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.PositionName).HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Professional>(entity =>
            {
                entity.ToTable("professional");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ProfessionalName).HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Professionalgroup>(entity =>
            {
                entity.ToTable("professionalgroup");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.DepartmentId).HasColumnType("int(11)");

                entity.Property(e => e.GroupLeader).HasColumnType("int(11)");

                entity.Property(e => e.ProfessionalGroupColore).HasColumnType("varchar(50)");

                entity.Property(e => e.ProfessionalGroupName).HasColumnType("varchar(50)");

                entity.Property(e => e.TeachingId).HasColumnType("int(11)");

                entity.Property(e => e.TeamMember).HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Isnable).HasColumnType("int(11)");

                entity.Property(e => e.PermissionName).HasColumnType("varchar(50)");

                entity.Property(e => e.RoleName).HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<RolePermission>(entity =>
            {
                entity.ToTable("role_permission");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Pid).HasColumnType("int(11)");

                entity.Property(e => e.Rid).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Rulesettings>(entity =>
            {
                entity.ToTable("rulesettings");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.OneShiftsId).HasColumnType("int(11)");

                entity.Property(e => e.TwoShiftsId).HasColumnType("int(11)");

                entity.Property(e => e.OneTime).HasColumnType("varchar(50)");

                entity.Property(e => e.TwoTime).HasColumnType("varchar(50)");

                entity.Property(e => e.ThreeTime).HasColumnType("varchar(50)");

                entity.Property(e => e.Types).HasColumnType("int(11)");

                entity.Property(e => e.Iseffec).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Shiftssetting>(entity =>
            {
                entity.ToTable("shiftssetting");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Closingtime).HasColumnType("datetime");

                entity.Property(e => e.Duration).HasColumnType("varchar(50)");

                entity.Property(e => e.Isclock).HasColumnType("int(11)");

                entity.Property(e => e.Opentime).HasColumnType("datetime");

                entity.Property(e => e.ShiftssettingName).HasColumnType("varchar(50)");

                entity.Property(e => e.Shiftssettingcolour).HasColumnType("varchar(50)");

                entity.Property(e => e.Shiftssettingtypeid).HasColumnType("int(11)");

                entity.Property(e => e.Sortid).HasColumnType("int(11)");

                entity.Property(e => e.Validday).HasColumnType("varchar(50)");

                entity.Property(e => e.Validtime).HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Times>(entity =>
            {
                entity.ToTable("times");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.DateTimes).HasColumnType("datetime");

                entity.Property(e => e.Remark).HasColumnType("varchar(100)");

                entity.Property(e => e.ShiftsId).HasColumnType("int(11)");

                entity.Property(e => e.UserId).HasColumnType("int(11)");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("user_role");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Rid).HasColumnType("int(11)");

                entity.Property(e => e.Uid).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Scheduling>(entity =>
            {
                entity.ToTable("scheduling");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Uid).HasColumnType("int(11)");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Week).HasColumnType("varchar(50)");

                entity.Property(e => e.ShiftssettingId).HasColumnType("int(11)");
            });
        }
    }
}
