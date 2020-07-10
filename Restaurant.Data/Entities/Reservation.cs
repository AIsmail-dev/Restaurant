using Restaurant.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Restaurant.Data
{
    [Table("Reservation", Schema = "Restaurant")]
    public class Reservation
    {
        [Key]
        public int ReservationId { get; private set; }

        [Required]
        public long GuestNumber { get; private set; }

        [Required]
        public DateTime ReservationDate { get; private set; }

        [Required]
        public int MenuTypeId { get; private set; }

        [NotMapped]
        public MenuTypeEnum MenuTypeEnum => (MenuTypeEnum)MenuTypeId;

        [StringLength(300)]
        public string Notes { get; private set; }

        #region Methods

        public Reservation(long guestNumber, DateTime reservationDate, int menuTypeId, string notes)
        {
            GuestNumber = guestNumber;
            ReservationDate = reservationDate;
            MenuTypeId = menuTypeId;
            Notes = notes;
        }

        #endregion
    }
}
