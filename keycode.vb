Module keycode
    Public Declare Function InitKeyCode Lib "keycode.dll" Alias "IInitKeyCode" (ByVal ty As Int32, ByVal pas As String) As Int32
    Public Declare Function FreeKeyCode Lib "keycode.dll" Alias "IFreeKeyCode" (ByVal idx As Int32) As Long
    Public Declare Function GetCode Lib "keycode.dll" Alias "IGetCode" (ByVal FileName As String, ByVal outText As String, ByVal idx As Int32) As Long
    Public Declare Function GetCodeByBitmap Lib "keycode.dll" Alias "IGetCodeByBitmap" (ByVal pic As Bitmap, ByVal pOutBuf As String, ByVal idx As Int32) As Long
End Module
