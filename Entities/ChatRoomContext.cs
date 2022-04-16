using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entities
{
    public partial class ChatRoomContext : DbContext
    {
        public ChatRoomContext()
        {
        }

        public ChatRoomContext(DbContextOptions<ChatRoomContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chat> Chats { get; set; } = null!;
        public virtual DbSet<ChatUser> ChatUsers { get; set; } = null!;
        public virtual DbSet<MsgDatum> MsgData { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<VwuserToChatMsg> VwuserToChatMsgs { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chat>(entity =>
            {
                entity.ToTable("Chat");

                entity.Property(e => e.ChatId).HasColumnName("ChatID");

                entity.Property(e => e.ChatName).HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ChatUser>(entity =>
            {
                entity.ToTable("ChatUser");

                entity.HasIndex(e => e.ChatId, "IX_ChatUser_ChatID");

                entity.HasIndex(e => e.UserId, "IX_ChatUser_UserID");

                entity.Property(e => e.ChatUserId).HasColumnName("ChatUserID");

                entity.Property(e => e.ChatId).HasColumnName("ChatID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Chat)
                    .WithMany(p => p.ChatUsers)
                    .HasForeignKey(d => d.ChatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChatUser_Chat");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ChatUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChatUser_User");
            });

            modelBuilder.Entity<MsgDatum>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => e.ChatUserId, "IX_MsgData_ChatUserID");

                entity.Property(e => e.ChatUserId).HasColumnName("ChatUserID");

                entity.Property(e => e.Message)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.PushDate).HasColumnType("datetime");

                entity.HasOne(d => d.ChatUser)
                    .WithMany()
                    .HasForeignKey(d => d.ChatUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MsgData_ChatUser");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.BasePass).HasMaxLength(50);

                entity.Property(e => e.EditDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.RegisterDate).HasColumnType("datetime");

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            modelBuilder.Entity<VwuserToChatMsg>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VWUserToChatMsg");

                entity.Property(e => e.ChatId).HasColumnName("ChatID");

                entity.Property(e => e.Message)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.PushDate).HasColumnType("datetime");

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
