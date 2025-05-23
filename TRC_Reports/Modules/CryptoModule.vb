
Imports System.Security.Cryptography
    Imports System.Text
    Imports System.IO

Module CryptoModule

    ' Key and IV must be 16, 24, or 32 bytes (depending on AES mode)
    Private ReadOnly aesKey As String = "Magnaye2143@#XXX"  ' 16 characters = 128-bit key
    Private ReadOnly aesIV As String = "Magnaye2143@#XXX"   ' 16 characters = 128-bit IV

    Public Function EncryptPassword(plainText As String) As String
        Dim aes As Aes = Aes.Create()
        aes.Key = Encoding.UTF8.GetBytes(aesKey)
        aes.IV = Encoding.UTF8.GetBytes(aesIV)

        Using ms As New MemoryStream()
            Using cs As New CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write)
                Using sw As New StreamWriter(cs)
                    sw.Write(plainText)
                End Using
            End Using
            Return Convert.ToBase64String(ms.ToArray())
        End Using
    End Function

    Public Function DecryptPassword(cipherText As String) As String
        Try
            Dim aes As Aes = Aes.Create()
            aes.Key = Encoding.UTF8.GetBytes(aesKey)
            aes.IV = Encoding.UTF8.GetBytes(aesIV)

            Dim buffer As Byte() = Convert.FromBase64String(cipherText)
            Using ms As New MemoryStream(buffer)
                Using cs As New CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read)
                    Using sr As New StreamReader(cs)
                        Return sr.ReadToEnd()
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Return "DECRYPTION_ERROR"
        End Try
    End Function

End Module

