Module Module1
    Public mycon1 As String = My.Settings.mycon1
    'password 1r1d2m7s1d1atabase
    Public con As String = "Server=" + mycon1 + ";User Id=rdms_user;database=dbliquidation;password=1r1d2m7s1d1atabase;Persist Security Info=True"
    'Public con As String = "Server=" + mycon1 + ";User Id=rdms_user;database=dbliquidation;password=12345678;Persist Security Info=True"
    'Public conTEST As String = "Server=" + mycon1 + ";User Id=root;database=dbliquidation;password=12345678;Persist Security Info=True"

    Public mycon2 As String = My.Settings.mycon2

    Public con2 As String = "Server=" + mycon2 + ";User Id=rdms_user;database=rdms_db;password=1r1d2m7s1d1atabase;Persist Security Info=True"

End Module
