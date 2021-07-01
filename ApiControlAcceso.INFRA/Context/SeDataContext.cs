using ApiControlAcceso.MODELS.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Infrastructure;

namespace ApiControlAcceso.INFRA.Context
{
    public partial class SeDataContext : DbContext
    {
        public SeDataContext()
        {
            var adapter = (IObjectContextAdapter)this;
            var objectContext = adapter.ObjectContext;
            objectContext.CommandTimeout = 180;
        }

        public SeDataContext(DbContextOptions<SeDataContext> options)
            : base(options)
        {
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserSp> SpUsers { get; set; }
        public virtual DbSet<CustomFieldsUsser> CustomField { get; set; }
        public virtual DbSet<CustomFields> CustomFields { get; set; }
        public virtual DbSet<CustomFieldListGroupDatum> CustomFieldListGroupData { get; set; }
        public virtual DbSet<RecordGroup> RecordGroups { get; set; }
        public virtual DbSet<UserCustomFieldGroupDatum> UserCustomFieldGroupData { get; set; }
        public virtual DbSet<UserCardNumberGroupDatum> UserCardNumberGroupData { get; set; }
        public virtual DbSet<UserAccessLevelGroupDatum> UserAccessLevelGroupData { get; set; }
        public virtual DbSet<AccessLevel> AccessLevels { get; set; }
        public virtual DbSet<Site> Sites { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=AGILSOLUTIONS;Database=SecurityExpert;User Id=Integrator;Password=Medellin1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomFields>(entity =>
            {
                entity.HasKey(e => new { e.CustomFieldId, e.SiteId });

                entity.Property(e => e.CustomFieldId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CustomFieldID");

                entity.Property(e => e.SiteId).HasColumnName("SiteID");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.DefaultValue)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastModified).HasColumnType("datetime");

                entity.Property(e => e.LastOperator)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Name2)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RecordGroup).HasDefaultValueSql("(0x7FFFFFFF)");

                entity.Property(e => e.Tab).HasDefaultValueSql("(0x7FFFFFFF)");
            });

            modelBuilder.Entity<Site>(entity =>
            {
                entity.HasKey(e => e.SiteId);

                entity.Property(e => e.SiteId).HasColumnName("SiteID");

                entity.Property(e => e.AccessLevelAttribute)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ActiveDirectoryDomain)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Addess3)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Address2)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AdsyncPeriod)
                    .HasColumnName("ADSyncPeriod")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.AlarmStatusPage).HasDefaultValueSql("(0x7FFFFFFF)");

                entity.Property(e => e.CalendarActionsVisibility).HasDefaultValueSql("((1))");

                entity.Property(e => e.CardNumberAttribute)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.DefaultEnrollmentReader).HasDefaultValueSql("(0x7FFFFFFF)");

                entity.Property(e => e.DefaultFacilityNumber)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasDefaultValueSql("('100')");

                entity.Property(e => e.DefaultFloorPlan).HasDefaultValueSql("(0x7FFFFFFF)");

                entity.Property(e => e.DefaultPinlength)
                    .HasColumnName("DefaultPINLength")
                    .HasDefaultValueSql("((6))");

                entity.Property(e => e.DefaultSaltoEncoder)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DefaultSiteUsersInactivityDeletionPeriodAction).HasDefaultValueSql("((1))");

                entity.Property(e => e.DefaultSiteUsersInactivityDeletionPeriodInMinutes).HasDefaultValueSql("((43200))");

                entity.Property(e => e.DefaultSiteUsersInactivityPeriodAction).HasDefaultValueSql("((1))");

                entity.Property(e => e.DefaultSiteUsersInactivityPeriodInMinutes).HasDefaultValueSql("((43200))");

                entity.Property(e => e.DefaultStatusPage).HasDefaultValueSql("(0x7FFFFFFF)");

                entity.Property(e => e.DefaultUserExpiryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DefaultUserStartDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DefaultUsersInactivityPeriodAction).HasDefaultValueSql("((1))");

                entity.Property(e => e.DefaultUsersInactivityPeriodInMinutes).HasDefaultValueSql("((43200))");

                entity.Property(e => e.DisableAdusers).HasColumnName("DisableADUsers");

                entity.Property(e => e.DisableAdusersDeleted)
                    .HasColumnName("DisableADUsersDeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Duration)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("EMail")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EnableKwintegration)
                    .HasColumnName("EnableKWIntegration")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EnableKwlogging)
                    .HasColumnName("EnableKWLogging")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EndingAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EnhancedSecDenyPinDuplicate)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.EventWindow1).HasDefaultValueSql("(0x7FFFFFFF)");

                entity.Property(e => e.EventWindow2).HasDefaultValueSql("(0x7FFFFFFF)");

                entity.Property(e => e.EventWindow3).HasDefaultValueSql("(0x7FFFFFFF)");

                entity.Property(e => e.EventWindow4).HasDefaultValueSql("(0x7FFFFFFF)");

                entity.Property(e => e.EventWindow5).HasDefaultValueSql("(0x7FFFFFFF)");

                entity.Property(e => e.EventWindow6).HasDefaultValueSql("(0x7FFFFFFF)");

                entity.Property(e => e.ExportEnabled)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ExportFolder)
                    .IsRequired()
                    .HasMaxLength(512)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExportLastRunTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ExportNextRunTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FaxNumber)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FileNameCustomFieldId)
                    .HasColumnName("FileNameCustomFieldID")
                    .HasDefaultValueSql("(0x7FFFFFFF)");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Ipaddress)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("IPAddress")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Ipport).HasColumnName("IPPort");

                entity.Property(e => e.KabaBranchName)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.KabaCenTranInputPath)
                    .IsRequired()
                    .HasMaxLength(512)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.KabaCenTranOutputPath)
                    .IsRequired()
                    .HasMaxLength(512)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.KabaCommandTimeout).HasDefaultValueSql("((30))");

                entity.Property(e => e.KabaDispatcherId)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("KabaDispatcherID")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.KabaSynchInterval).HasDefaultValueSql("((5))");

                entity.Property(e => e.KeyWatcherUserIddigitLength)
                    .HasColumnName("KeyWatcherUserIDDigitLength")
                    .HasDefaultValueSql("((4))");

                entity.Property(e => e.Kwipaddress)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("KWIPAddress")
                    .HasDefaultValueSql("('0.0.0.0')");

                entity.Property(e => e.Kwipport)
                    .HasColumnName("KWIPPort")
                    .HasDefaultValueSql("((3005))");

                entity.Property(e => e.KwsyncInterval)
                    .HasColumnName("KWSyncInterval")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastEventId).HasColumnName("LastEventID");

                entity.Property(e => e.LastModified).HasColumnType("datetime");

                entity.Property(e => e.LastOperator)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LogAllTransaction)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.MasterKey)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MaximumRepeativeDigitsInPin)
                    .HasColumnName("MaximumRepeativeDigitsInPIN")
                    .HasDefaultValueSql("(0x7FFFFFFF)");

                entity.Property(e => e.MaximumSequentialDigitsInPin)
                    .HasColumnName("MaximumSequentialDigitsInPIN")
                    .HasDefaultValueSql("(0x7FFFFFFF)");

                entity.Property(e => e.MifareAkey)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("MifareAKey")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MifareBkey)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("MifareBKey")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MinimumPinlength)
                    .HasColumnName("MinimumPINLength")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Name2)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NewPintobeGeneratedBySystem).HasColumnName("NewPINtobeGeneratedBySystem");

                entity.Property(e => e.OneTimeStartTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OrganizationName)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PinExpiryTime).HasDefaultValueSql("((90))");

                entity.Property(e => e.PrincetonCredentialType).HasDefaultValueSql("(0x7FFFFFFF)");

                entity.Property(e => e.PrincetonDefaultEnrollmentReader).HasDefaultValueSql("(0x7FFFFFFF)");

                entity.Property(e => e.PrincetonDefaultFacilityNumber)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasDefaultValueSql("('100')");

                entity.Property(e => e.PrincetonIdentityIpaddress)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("PrincetonIdentityIPAddress")
                    .HasDefaultValueSql("('0.0.0.0')");

                entity.Property(e => e.PrincetonIdentityIpport).HasColumnName("PrincetonIdentityIPPort");

                entity.Property(e => e.PrincetonIdentityPassword)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PrincetonIdentityUsername)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SitePhotoPlaceHolderHeightPixels).HasDefaultValueSql("((400))");

                entity.Property(e => e.SitePhotoPlaceHolderWidthPixels).HasDefaultValueSql("((300))");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.StartingAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.StartingAt2)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.WebSite)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WindowsGroup)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValueSql("('Protege GX Users')");
            });

            modelBuilder.Entity<AccessLevel>(entity =>
            {
                entity.HasKey(e => new { e.AccessLevelId, e.SiteId });

                entity.Property(e => e.AccessLevelId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("AccessLevelID");

                entity.Property(e => e.SiteId).HasColumnName("SiteID");

                entity.Property(e => e.AccessLevelAreaGroup).HasDefaultValueSql("(0x7FFFFFFF)");

                entity.Property(e => e.AccessLevelAreaGroup2).HasDefaultValueSql("(0x7FFFFFFF)");

                entity.Property(e => e.AccessLevelDoor).HasDefaultValueSql("(0x7FFFFFFF)");

                entity.Property(e => e.AccessLevelDoorGroup).HasDefaultValueSql("(0x7FFFFFFF)");

                entity.Property(e => e.AccessLevelElevatorGroup).HasDefaultValueSql("(0x7FFFFFFF)");

                entity.Property(e => e.AccessLevelFloor).HasDefaultValueSql("(0x7FFFFFFF)");

                entity.Property(e => e.AccessLevelFloorGroup).HasDefaultValueSql("(0x7FFFFFFF)");

                entity.Property(e => e.AccessLevelKabaLockGroup).HasDefaultValueSql("(0x7FFFFFFF)");

                entity.Property(e => e.AccessLevelKabaLockId)
                    .HasColumnName("AccessLevelKabaLockID")
                    .HasDefaultValueSql("(0x7FFFFFFF)");

                entity.Property(e => e.AccessLevelKeyWatcherKeys).HasDefaultValueSql("(0x7FFFFFFF)");

                entity.Property(e => e.AccessLevelKeyWatcherKeysGroup).HasDefaultValueSql("(0x7FFFFFFF)");

                entity.Property(e => e.AccessLevelMenuGroup).HasDefaultValueSql("(0x7FFFFFFF)");

                entity.Property(e => e.AccessLevelPgm)
                    .HasColumnName("AccessLevelPGM")
                    .HasDefaultValueSql("(0x7FFFFFFF)");

                entity.Property(e => e.AccessLevelPgmgroup)
                    .HasColumnName("AccessLevelPGMGroup")
                    .HasDefaultValueSql("(0x7FFFFFFF)");

                entity.Property(e => e.Commands)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.ElevatorDestinationFloor).HasDefaultValueSql("(0x7FFFFFFF)");

                entity.Property(e => e.EnableMultiBadgeArming)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IncludeAllArmingAreas).HasDefaultValueSql("((0))");

                entity.Property(e => e.IncludeAllDisArmingAreas).HasDefaultValueSql("((0))");

                entity.Property(e => e.IncludeAllDoors).HasDefaultValueSql("((0))");

                entity.Property(e => e.IncludeAllElevators).HasDefaultValueSql("((0))");

                entity.Property(e => e.IncludeAllFloors).HasDefaultValueSql("((0))");

                entity.Property(e => e.KeypadAccessActivatesPgm).HasColumnName("KeypadAccessActivatesPGM");

                entity.Property(e => e.LastModified).HasColumnType("datetime");

                entity.Property(e => e.LastOperator)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasDefaultValueSql("('Access Level')");

                entity.Property(e => e.Name2)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OperatingSchedule).HasDefaultValueSql("(0x7FFFFFFF)");

                entity.Property(e => e.ReaderAccessActivatesPgm).HasColumnName("ReaderAccessActivatesPGM");

                entity.Property(e => e.RecordGroup).HasDefaultValueSql("(0x7FFFFFFF)");

                entity.Property(e => e.ResetPeriodType).HasDefaultValueSql("((3))");

                entity.Property(e => e.SchindlerTemplate)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Seindex).HasColumnName("SEIndex");

                entity.Property(e => e.TimeToActivatePgm).HasColumnName("TimeToActivatePGM");
            });

            modelBuilder.Entity<UserAccessLevelGroupDatum>(entity =>
            {
                entity.HasKey(e => new { e.Id });
                
                entity.Property(e => e.UserAccessLevelEnd)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserAccessLevelGroupDataId).HasColumnName("UserAccessLevelGroupDataID");

                entity.Property(e => e.UserAccessLevelSchedule).HasDefaultValueSql("((2147483647))");

                entity.Property(e => e.UserAccessLevelStart)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<UserCardNumberGroupDatum>(entity =>
            {
                entity.HasKey(e => new { e.UserId});
                entity.HasIndex(e => new { e.Site, e.CardNumber, e.FamilyNumber }, "UserCardNumberIndex")
                    .IsUnique();

                entity.HasIndex(e => new { e.CardDisabled, e.CardInactivityPeriodIsActive }, "ixUserCardInactivityIsActive");

                entity.Property(e => e.CardInactivityPeriodAction).HasDefaultValueSql("((1))");

                entity.Property(e => e.CardInactivityPeriodInMinutes).HasDefaultValueSql("((43200))");

                entity.Property(e => e.CardLastUsed)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(CONVERT([datetime],'1970-01-01 00:00:00',(101)))");

                entity.Property(e => e.CardNumber)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FamilyNumber)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UserCardNumberGroupDataId).HasColumnName("UserCardNumberGroupDataID");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<UserCustomFieldGroupDatum>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.CustomFieldId })
                    .HasName("pk_UserCustomFieldGroupData__UserID_CustomFieldID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.CustomFieldId).HasColumnName("CustomFieldID");

                entity.Property(e => e.CustomFieldBooleanData)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CustomFieldDateTimeData).HasColumnType("datetime");

                entity.Property(e => e.CustomFieldTextData)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UserCustomFieldGroupDataId).HasColumnName("UserCustomFieldGroupDataID");
            });

            modelBuilder.Entity<RecordGroup>(entity =>
            {
                entity.HasKey(e => new { e.RecordGroupId, e.SiteId });

                entity.Property(e => e.RecordGroupId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("RecordGroupID");

                entity.Property(e => e.SiteId).HasColumnName("SiteID");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.LastModified).HasColumnType("datetime");

                entity.Property(e => e.LastOperator)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Name2)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RecordGroup1)
                    .HasColumnName("RecordGroup")
                    .HasDefaultValueSql("(0x7FFFFFFF)");

                entity.Property(e => e.TextData)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<UserSp>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<CustomFieldListGroupDatum>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CustomFieldId).HasColumnName("CustomFieldID");

                entity.Property(e => e.CustomFieldListGroupDataId).HasColumnName("CustomFieldListGroupDataID");

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.SiteId });

                entity.HasIndex(e => e.KabaKeyId, "IX_Users_KabaKeyID");

                entity.HasIndex(e => e.UserInactivityDeletionPeriodIsActive, "ixUserInactivityDeletionPeriodIsActive");

                entity.HasIndex(e => e.UserInactivityPeriodIsActive, "ixUserInactivityPeriodIsActive");

                entity.Property(e => e.UserId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("UserID");

                entity.Property(e => e.SiteId).HasColumnName("SiteID");

                entity.Property(e => e.AuditOpeningsInTheKey)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.BadgeNumber)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BadgeType)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BiometricFaceData)
                    .IsRequired()
                    .HasColumnType("ntext")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Calendar).HasDefaultValueSql("(0x7FFFFFFF)");

                entity.Property(e => e.CardNumber)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CardType)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CustomField1)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustomField2)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustomField3)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustomField4)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustomField5)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustomNoteField1)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustomNoteField2)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DateOfBadgeProduction).HasColumnType("datetime");

                entity.Property(e => e.DoorGroupException).HasDefaultValueSql("(0x7FFFFFFF)");

                entity.Property(e => e.EmployeeFunction)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EnableRevalidationOfKeyExpiration)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.EnrollmentDevice).HasDefaultValueSql("(0x7FFFFFFF)");

                entity.Property(e => e.ExpirationDateOfBadge).HasColumnType("datetime");

                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.ExpiryTime).HasColumnType("datetime");

                entity.Property(e => e.ExternalData)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExternalData2)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Finger1)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FingerData)
                    .IsRequired()
                    .HasMaxLength(1536)
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FingerData2)
                    .IsRequired()
                    .HasMaxLength(1536)
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.HlienableCartService).HasColumnName("HLIEnableCartService");

                entity.Property(e => e.HlienableCimoverride).HasColumnName("HLIEnableCIMOverride");

                entity.Property(e => e.HlienableSplitGroup).HasColumnName("HLIEnableSplitGroup");

                entity.Property(e => e.HlienableVertigo).HasColumnName("HLIEnableVertigo");

                entity.Property(e => e.HlienableVertigo2).HasColumnName("HLIEnableVertigo2");

                entity.Property(e => e.HliisVipuser).HasColumnName("HLIIsVIPUser");

                entity.Property(e => e.Image2Id)
                    .HasColumnName("Image2ID")
                    .HasDefaultValueSql("(0x7FFFFFFF)");

                entity.Property(e => e.ImageId)
                    .HasColumnName("ImageID")
                    .HasDefaultValueSql("(0x7FFFFFFF)");

                entity.Property(e => e.KabaBankUserId)
                    .HasColumnName("KabaBankUserID")
                    .HasDefaultValueSql("(0x7FFFFFFF)");

                entity.Property(e => e.KabaKeyId)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("KabaKeyID")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.KabaPinchanged).HasColumnName("KabaPINChanged");

                entity.Property(e => e.KeyAssigned)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastModified).HasColumnType("datetime");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastOperator)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastPinUpdate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(CONVERT([datetime],'2000-01-01T00:00:00.000',(126)))");

                entity.Property(e => e.LegacyPhotoIdDisplayMode)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LicenseNumber)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Name2)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NotificationAddress)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PhotoIdtemplate)
                    .HasColumnName("PhotoIDTemplate")
                    .HasDefaultValueSql("(0x7FFFFFFF)");

                entity.Property(e => e.Pin).HasColumnName("PIN");

                entity.Property(e => e.PinexpiryTimeOnUser).HasColumnName("PINExpiryTimeOnUser");

                entity.Property(e => e.Pinnumber)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("PINNumber")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RecordGroup).HasDefaultValueSql("(0x7FFFFFFF)");

                entity.Property(e => e.ReportingId).HasColumnName("ReportingID");

                entity.Property(e => e.SalaryNumber)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SaltoKeyData)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SaltoKeyValidUntil).HasColumnType("datetime");

                entity.Property(e => e.Seindex).HasColumnName("SEIndex");

                entity.Property(e => e.ServiceName)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ServiceNumber)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Showagreetingmessagetouser)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Site)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.SupportsVms).HasColumnName("SupportsVMS");

                entity.Property(e => e.TreatUserPinless1AsDuress).HasColumnName("TreatUserPINLess1AsDuress");

                entity.Property(e => e.Union)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UpdatePeriod).HasDefaultValueSql("((30))");

                entity.Property(e => e.UserActivation).HasColumnType("datetime");

                entity.Property(e => e.UserArea).HasDefaultValueSql("(0x7FFFFFFF)");

                entity.Property(e => e.UserAreaGroup).HasDefaultValueSql("(0x7FFFFFFF)");

                entity.Property(e => e.UserExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.UserInactivityDeletionPeriodAction).HasDefaultValueSql("((1))");

                entity.Property(e => e.UserInactivityDeletionPeriodInMinutes).HasDefaultValueSql("((43200))");

                entity.Property(e => e.UserInactivityPeriodAction).HasDefaultValueSql("((1))");

                entity.Property(e => e.UserInactivityPeriodInMinutes).HasDefaultValueSql("((43200))");

                entity.Property(e => e.UserKabaLock).HasDefaultValueSql("(0x7FFFFFFF)");

                entity.Property(e => e.UserKeyWatcherId)
                    .HasColumnName("UserKeyWatcherID")
                    .HasDefaultValueSql("(0x7FFFFFFF)");

                entity.Property(e => e.UserLastActive)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(CONVERT([datetime],'1970-01-01 00:00:00',(101)))");

                entity.Property(e => e.UserOperatesAdafunction).HasColumnName("UserOperatesADAFunction");

                entity.Property(e => e.UserPhotoPlaceHolderHeightPixels).HasDefaultValueSql("((400))");

                entity.Property(e => e.UserPhotoPlaceHolderWidthPixels).HasDefaultValueSql("((300))");

                entity.Property(e => e.UserRoom).HasDefaultValueSql("(0x7FFFFFFF)");

                entity.Property(e => e.UserType).HasDefaultValueSql("((8))");

                entity.Property(e => e.VisitorAccessLevel).HasDefaultValueSql("(0x7FFFFFFF)");

                entity.Property(e => e.VmscardIndex)
                    .HasColumnName("VMSCardIndex")
                    .HasDefaultValueSql("(0x7FFFFFFF)");

                entity.Property(e => e.VmscheckedIn)
                    .HasColumnType("datetime")
                    .HasColumnName("VMSCheckedIn");

                entity.Property(e => e.VmscheckedOut)
                    .HasColumnType("datetime")
                    .HasColumnName("VMSCheckedOut");

                entity.Property(e => e.VmsexpectedLeaveDate)
                    .HasColumnType("datetime")
                    .HasColumnName("VMSExpectedLeaveDate");

                entity.Property(e => e.Vmsstatus).HasColumnName("VMSStatus");

                entity.Property(e => e.VmstemplateId)
                    .HasColumnName("VMSTemplateID")
                    .HasDefaultValueSql("(0x7FFFFFFF)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
