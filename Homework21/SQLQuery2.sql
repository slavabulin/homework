CREATE TRIGGER [dbo].[trg_Table2]
ON [dbo].[Lecture] AFTER UPDATE 
AS
BEGIN

   IF UPDATE (Date)
   BEGIN

   INSERT INTO Attendance (LectureDate)
   SELECT Date FROM inserted LectureDate



   END


END