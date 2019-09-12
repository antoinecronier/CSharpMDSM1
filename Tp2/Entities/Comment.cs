using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp2.Entities.Schemas;

namespace Tp2.Entities
{
    [Table(CommentSchema.TABLE)]
    public class Comment
    {
        private int? id;
        private DateTime commentAt;
        private String data;
        private User from;
        private User to;

        [PrimaryKey]
        [AutoIncrement]
        [Column(CommentSchema.ID)]
        public int? Id
        {
            get { return id; }
            set { id = value; }
        }

        [Column(CommentSchema.COMMENT_AT)]
        public DateTime CommentAt
        {
            get { return commentAt; }
            set { commentAt = value; }
        }

        [Column(CommentSchema.DATA)]
        public String Data
        {
            get { return data; }
            set { data = value; }
        }

        [ForeignKey(typeof(User))]
        public int? FromId { get; set; }

        [ManyToOne("FromId")]
        public User From
        {
            get { return from; }
            set { from = value; }
        }

        [ForeignKey(typeof(User))]
        public int? ToId { get; set; }

        [ManyToOne("ToId")]
        public User To
        {
            get { return to; }
            set { to = value; }
        }

        public Comment()
        {

        }

        public override string ToString()
        {
            return String.Format("\"{0}\":\"{1}\",\"{2}\":\"{3}\",\"{4}\":\"{5}\",\"{6}\":\"{7}\",\"{8}\":\"{9}\"",
                CommentSchema.ID, this.Id,
                CommentSchema.COMMENT_AT, this.CommentAt,
                CommentSchema.DATA, this.Data,
                CommentSchema.FK_USER_FROM, this.From,
                CommentSchema.FK_USER_TO, this.To);
        }
    }
}
