﻿Imports System.Security.Claims
Imports System.Threading.Tasks
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin

Namespace T680906.Models
	' You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
	Public Class ApplicationUser
		Inherits IdentityUser

		Public Async Function GenerateUserIdentityAsync(ByVal manager As UserManager(Of ApplicationUser), ByVal authenticationType As String) As Task(Of ClaimsIdentity)
			' Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
			Dim userIdentity = Await manager.CreateIdentityAsync(Me, authenticationType)
			' Add custom user claims here
			Return userIdentity
		End Function
	End Class

	Public Class ApplicationDbContext
		Inherits IdentityDbContext(Of ApplicationUser)

		Public Sub New()
			MyBase.New("DefaultConnection", throwIfV1Schema:= False)
		End Sub

		Public Shared Function Create() As ApplicationDbContext
			Return New ApplicationDbContext()
		End Function
	End Class
End Namespace