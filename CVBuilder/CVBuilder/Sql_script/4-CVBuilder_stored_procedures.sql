use CVBuilder
go

create procedure usp_Curriculum_Create
@id_user nvarchar(128),
@id_curriculum_inserted integer output
as
begin
	begin try
		if not exists (
			select 1
			from dbo.AspNetUsers
			where Id = @id_user
		)
		begin
			raiserror('El id de usuario indicado no existe.',16,1)
			return
		end

		if exists (
			select 1
			from cvbuilder.Curriculum
			where ID_User = @id_user
		)
		begin
			raiserror('Este usuario ya tiene un curriculum creado.',16,1)
			return
		end

		insert into cvbuilder.Curriculum (ID_User, ID_Template, StudiesIsVisible, WorkExperiencesIsVisible, CertificatesIsVisible, LanguagesIsVisible, SkillsIsVisible, InterestsIsVisible, PersonalReferencesIsVisible, CustomSectionsIsVisible)
		values (@id_user, 1, 1, 1, 1, 1, 1, 1, 1, 1)
		set @id_curriculum_inserted = SCOPE_IDENTITY()
	end try
	begin catch
		declare @ErrorMessage nvarchar(4000)
		declare @ErrorSeverity integer
		declare @ErrorState integer

		select 
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE()

		-- Use RAISERROR inside the CATCH block to return error
		-- information about the original error that caused
		-- execution to jump to the CATCH block.
		raiserror (
			@ErrorMessage, -- Message text.
			@ErrorSeverity, -- Severity.
			@ErrorState -- State.
		)
		return
	end catch
end
go

create procedure usp_Curriculum_Update
@id_curriculum integer,
@id_user nvarchar(128),
@id_template integer
as
begin
	begin try
		if not exists (
			select 1
			from dbo.AspNetUsers
			where Id = @id_user
		)
		begin
			raiserror('El id de usuario indicado no existe.',16,1)
			return
		end

		if not exists (
			select 1
			from cvbuilder.Curriculum
			where CurriculumID = @id_curriculum
		)
		begin
			raiserror('El id del curriculum indicado no existe.',16,1)
			return
		end

		if not exists (
			select 1
			from cvbuilder.Templates
			where TemplateID = @id_template
		)
		begin
			raiserror('El id de plantilla indicado no existe.',16,1)
			return
		end

		update cvbuilder.Curriculum set ID_Template = @id_template
									where CurriculumID = @id_curriculum
									and ID_User = @id_user
	end try
	begin catch
		declare @ErrorMessage nvarchar(4000)
		declare @ErrorSeverity integer
		declare @ErrorState integer

		select 
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE()

		-- Use RAISERROR inside the CATCH block to return error
		-- information about the original error that caused
		-- execution to jump to the CATCH block.
		raiserror (
			@ErrorMessage, -- Message text.
			@ErrorSeverity, -- Severity.
			@ErrorState -- State.
		)
		return
	end catch
end
go

create procedure usp_Curriculum_Delete
@id_curriculum integer,
@id_user nvarchar(128)
as
begin
	begin try
		if not exists (
			select 1
			from dbo.AspNetUsers
			where Id = @id_user
		)
		begin
			raiserror('El id de usuario indicado no existe.',16,1)
			return
		end

		if not exists (
			select 1
			from cvbuilder.Curriculum
			where CurriculumID = @id_curriculum
		)
		begin
			raiserror('El id del curriculum indicado no existe.',16,1)
			return
		end

		delete from cvbuilder.Certificates where ID_Curriculum = @id_curriculum
		delete from cvbuilder.CustomSections where ID_Curriculum = @id_curriculum
		delete from cvbuilder.Interests where ID_Curriculum = @id_curriculum
		delete from cvbuilder.Languages where ID_Curriculum = @id_curriculum
		delete from cvbuilder.PersonalDetails where ID_Curriculum = @id_curriculum
		delete from cvbuilder.PersonalReferences where ID_Curriculum = @id_curriculum
		delete from cvbuilder.Skills where ID_Curriculum = @id_curriculum
		delete from cvbuilder.Studies where ID_Curriculum = @id_curriculum
		delete from cvbuilder.WorkExperiences where ID_Curriculum = @id_curriculum
		delete from cvbuilder.Curriculum where CurriculumID = @id_curriculum and ID_User = @id_user
	end try
	begin catch
		declare @ErrorMessage nvarchar(4000)
		declare @ErrorSeverity integer
		declare @ErrorState integer

		select 
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE()

		-- Use RAISERROR inside the CATCH block to return error
		-- information about the original error that caused
		-- execution to jump to the CATCH block.
		raiserror (
			@ErrorMessage, -- Message text.
			@ErrorSeverity, -- Severity.
			@ErrorState -- State.
		)
		return
	end catch
end
go

create procedure usp_PersonalDetails_Create
@name nvarchar(100),
@lastname nvarchar(100),
@email nvarchar(100),
@profession nvarchar(200),
@photo varbinary(max),
@mimeType nvarchar(25),
@address nvarchar(100),
@city nvarchar(100),
@postalCode integer,
@areaCodeLP smallint,
@linePhone integer,
@areaCodeMP smallint,
@mobilePhone integer,
@country nvarchar(100),
@summary nvarchar(300),
@summaryCustomTitle nvarchar(50),
@summaryIsVisible bit,
@webPageUrl nvarchar(300),
@linkedInUrl nvarchar(300),
@githubUrl nvarchar(300),
@facebookUrl nvarchar(300),
@twitterUrl nvarchar(300),
@id_curriculum integer
as
begin
	begin try
		if @photo is not null and (DATALENGTH(@photo) > 1048576)
		begin
			raiserror('La imágen es superior a 1 MB.',16,1)
			return
		end

		if not exists (
			select 1
			from cvbuilder.Curriculum
			where CurriculumID = @id_curriculum
		)
		begin
			raiserror('El curriculum no existe.',16,1)
			return
		end

		insert into cvbuilder.PersonalDetails (
			Name, LastName, Email, Profession, Photo, MimeType, Address, City, PostalCode, AreaCodeLP, LinePhone, AreaCodeMP, MobilePhone, Country, Summary, SummaryCustomTitle, SummaryIsVisible, WebPageUrl, LinkedInUrl, GithubUrl, FacebookUrl, TwitterUrl, ID_Curriculum
		)
		values (
			@name, @lastname, @email, @profession, @photo, @mimeType, @address, @city, @postalCode, @areaCodeLP, @linePhone, @areaCodeMP, @mobilePhone, @country, @summary, @summaryCustomTitle, @summaryIsVisible, @webPageUrl, @linkedInUrl, @githubUrl, @facebookUrl, @twitterUrl, @id_curriculum
		)
	end try
	begin catch
		declare @ErrorMessage nvarchar(4000)
		declare @ErrorSeverity integer
		declare @ErrorState integer

		select 
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE()

		-- Use RAISERROR inside the CATCH block to return error
		-- information about the original error that caused
		-- execution to jump to the CATCH block.
		raiserror (
			@ErrorMessage, -- Message text.
			@ErrorSeverity, -- Severity.
			@ErrorState -- State.
		)
		return
	end catch
end
go

create procedure usp_PersonalDetails_Update
@id integer,
@name nvarchar(100),
@lastname nvarchar(100),
@email nvarchar(100),
@profession nvarchar(200),
@photo varbinary(max),
@mimeType nvarchar(25),
@address nvarchar(100),
@city nvarchar(100),
@postalCode integer,
@areaCodeLP smallint,
@linePhone integer,
@areaCodeMP smallint,
@mobilePhone integer,
@country nvarchar(100),
@summary nvarchar(300),
@summaryCustomTitle nvarchar(50),
@summaryIsVisible bit,
@webPageUrl nvarchar(300),
@linkedInUrl nvarchar(300),
@githubUrl nvarchar(300),
@facebookUrl nvarchar(300),
@twitterUrl nvarchar(300),
@id_curriculum integer
as
	begin try
		if not exists (
			select 1
			from cvbuilder.PersonalDetails
			where PersonalDetailsID = @id
		)
		begin
			raiserror('El ítem indicado dentro de esta sección no existe.',16,1)
			return
		end

		if not exists (
			select 1
			from cvbuilder.Curriculum
			where CurriculumID = @id_curriculum
		)
		begin
			raiserror('El curriculum no existe.',16,1)
			return
		end

		if @photo is null or (DATALENGTH(@photo) <= 0)
		begin
			select @photo = Photo, @mimeType = MimeType
			from cvbuilder.PersonalDetails
			where PersonalDetailsID = @id
		end

		update cvbuilder.PersonalDetails set
			Name = @name,
			LastName = @lastname,
			Email = @email,
			Profession = @profession,
			Photo = @photo,
			MimeType = @mimeType,
			Address = @address,
			City = @city,
			PostalCode = @postalCode,
			AreaCodeLP = @areaCodeLP,
			LinePhone = @linePhone,
			AreaCodeMP = @areaCodeMP,
			MobilePhone = @mobilePhone,
			Country = @country,
			Summary = @summary,
			SummaryCustomTitle = @summaryCustomTitle,
			SummaryIsVisible = @summaryIsVisible,
			WebPageUrl = @webPageUrl,
			LinkedInUrl = @linkedInUrl,
			GithubUrl = @githubUrl,
			FacebookUrl = @facebookUrl,
			TwitterUrl = @twitterUrl,
			ID_Curriculum = @id_curriculum
		where PersonalDetailsID = @id
	end try
	begin catch
		declare @ErrorMessage nvarchar(4000)
		declare @ErrorSeverity integer
		declare @ErrorState integer

		select 
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE()

		-- Use RAISERROR inside the CATCH block to return error
		-- information about the original error that caused
		-- execution to jump to the CATCH block.
		raiserror (
			@ErrorMessage, -- Message text.
			@ErrorSeverity, -- Severity.
			@ErrorState -- State.
		)
		return
	end catch
go

create procedure usp_PersonalDetails_Delete
@id integer
as
begin
	begin try
		delete from cvbuilder.PersonalDetails
		where PersonalDetailsID = @id
	end try
	begin catch
		declare @ErrorMessage nvarchar(4000)
		declare @ErrorSeverity integer
		declare @ErrorState integer

		select 
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE()

		-- Use RAISERROR inside the CATCH block to return error
		-- information about the original error that caused
		-- execution to jump to the CATCH block.
		raiserror (
			@ErrorMessage, -- Message text.
			@ErrorSeverity, -- Severity.
			@ErrorState -- State.
		)
		return
	end catch
end
go

create procedure usp_Studies_Create
@title nvarchar(100),
@institute nvarchar(100),
@city nvarchar(100),
@startMonth nvarchar(50),
@startYear integer,
@endMonth nvarchar(50),
@endYear integer,
@description nvarchar(300),
@isVisible bit,
@id_curriculum integer
as
begin
	begin try
		if not exists (
			select 1
			from cvbuilder.Curriculum
			where CurriculumID = @id_curriculum
		)
		begin
			raiserror('El curriculum no existe.',16,1)
			return
		end

		insert into cvbuilder.Studies (
			Title, Institute, City, StartMonth, StartYear, EndMonth, EndYear, Description, IsVisible, ID_Curriculum
		)
		values (
			@title, @institute, @city, @startMonth, @startYear, @endMonth, @endYear, @description, @isVisible, @id_curriculum
		)
	end try
	begin catch
		declare @ErrorMessage nvarchar(4000)
		declare @ErrorSeverity integer
		declare @ErrorState integer

		select 
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE()

		-- Use RAISERROR inside the CATCH block to return error
		-- information about the original error that caused
		-- execution to jump to the CATCH block.
		raiserror (
			@ErrorMessage, -- Message text.
			@ErrorSeverity, -- Severity.
			@ErrorState -- State.
		)
		return
	end catch
end
go


create procedure usp_Studies_Update
@id integer,
@title nvarchar(100),
@institute nvarchar(100),
@city nvarchar(100),
@startMonth nvarchar(50),
@startYear integer,
@endMonth nvarchar(50),
@endYear integer,
@description nvarchar(300),
@isVisible bit,
@id_curriculum integer
as
begin
	begin try
		if not exists (
			select 1
			from cvbuilder.Studies
			where StudyID = @id
		)
		begin
			raiserror('El ítem indicado dentro de esta sección no existe.',16,1)
			return
		end

		if not exists (
			select 1
			from cvbuilder.Curriculum
			where CurriculumID = @id_curriculum
		)
		begin
			raiserror('El curriculum no existe.',16,1)
			return
		end

		update cvbuilder.Studies set
			Title = @title,
			Institute = @institute,
			City = @city,
			StartMonth = @startMonth,
			StartYear = @startYear,
			EndMonth = @endMonth,
			EndYear = @endYear,
			Description = @description,
			IsVisible = @isVisible,
			ID_Curriculum = @id_curriculum
		where StudyID = @id
	end try
	begin catch
		declare @ErrorMessage nvarchar(4000)
		declare @ErrorSeverity integer
		declare @ErrorState integer

		select 
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE()

		-- Use RAISERROR inside the CATCH block to return error
		-- information about the original error that caused
		-- execution to jump to the CATCH block.
		raiserror (
			@ErrorMessage, -- Message text.
			@ErrorSeverity, -- Severity.
			@ErrorState -- State.
		)
		return
	end catch
end
go

create procedure usp_Studies_Delete
@id integer
as
begin
	begin try
		delete from cvbuilder.Studies
		where StudyID = @id
	end try
	begin catch
		declare @ErrorMessage nvarchar(4000)
		declare @ErrorSeverity integer
		declare @ErrorState integer

		select 
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE()

		-- Use RAISERROR inside the CATCH block to return error
		-- information about the original error that caused
		-- execution to jump to the CATCH block.
		raiserror (
			@ErrorMessage, -- Message text.
			@ErrorSeverity, -- Severity.
			@ErrorState -- State.
		)
		return
	end catch
end
go

create procedure usp_WorkExperiences_Create
@job nvarchar(100),
@city nvarchar(100),
@company nvarchar(100),
@startMonth nvarchar(50),
@startYear integer,
@endMonth nvarchar(50),
@endYear integer,
@description nvarchar(300),
@isVisible bit,
@id_curriculum integer
as
begin
	begin try
		if not exists (
			select 1
			from cvbuilder.Curriculum
			where CurriculumID = @id_curriculum
		)
		begin
			raiserror('El curriculum no existe.',16,1)
			return
		end

		insert into cvbuilder.WorkExperiences (
			Job, City, Company, StartMonth, StartYear, EndMonth, EndYear, Description, IsVisible, ID_Curriculum
		)
		values (
			@job, @city, @company, @startMonth, @startYear, @endMonth, @endYear, @description, @isVisible, @id_curriculum
		)
	end try
	begin catch
		declare @ErrorMessage nvarchar(4000)
		declare @ErrorSeverity integer
		declare @ErrorState integer

		select 
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE()

		-- Use RAISERROR inside the CATCH block to return error
		-- information about the original error that caused
		-- execution to jump to the CATCH block.
		raiserror (
			@ErrorMessage, -- Message text.
			@ErrorSeverity, -- Severity.
			@ErrorState -- State.
		)
		return
	end catch
end
go

create procedure usp_WorkExperiences_Update
@id integer,
@job nvarchar(100),
@city nvarchar(100),
@company nvarchar(100),
@startMonth nvarchar(50),
@startYear integer,
@endMonth nvarchar(50),
@endYear integer,
@description nvarchar(300),
@isVisible bit,
@id_curriculum integer
as
begin
	begin try
		if not exists (
			select 1
			from cvbuilder.WorkExperiences
			where WorkExperienceID = @id
		)
		begin
			raiserror('El ítem indicado dentro de esta sección no existe.',16,1)
			return
		end

		if not exists (
			select 1
			from cvbuilder.Curriculum
			where CurriculumID = @id_curriculum
		)
		begin
			raiserror('El curriculum no existe.',16,1)
			return
		end

		update cvbuilder.WorkExperiences set
			Job = @job,
			City = @city,
			Company = @company,
			StartMonth = @startMonth,
			StartYear = @startYear,
			EndMonth = @endMonth,
			EndYear = @endYear,
			Description = @description,
			IsVisible = @isVisible,
			ID_Curriculum = @id_curriculum
		where WorkExperienceID = @id
	end try
	begin catch
		declare @ErrorMessage nvarchar(4000)
		declare @ErrorSeverity integer
		declare @ErrorState integer

		select 
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE()

		-- Use RAISERROR inside the CATCH block to return error
		-- information about the original error that caused
		-- execution to jump to the CATCH block.
		raiserror (
			@ErrorMessage, -- Message text.
			@ErrorSeverity, -- Severity.
			@ErrorState -- State.
		)
		return
	end catch
end
go

create procedure usp_WorkExperiences_Delete
@id integer
as
begin
	begin try
		delete from cvbuilder.WorkExperiences
		where WorkExperienceID = @id
	end try
	begin catch
		declare @ErrorMessage nvarchar(4000)
		declare @ErrorSeverity integer
		declare @ErrorState integer

		select 
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE()

		-- Use RAISERROR inside the CATCH block to return error
		-- information about the original error that caused
		-- execution to jump to the CATCH block.
		raiserror (
			@ErrorMessage, -- Message text.
			@ErrorSeverity, -- Severity.
			@ErrorState -- State.
		)
		return
	end catch
end
go

create procedure usp_Certificates_Create
@name nvarchar(100),
@institute nvarchar(100),
@onlineMode bit,
@inProgress bit,
@year integer,
@description nvarchar(300),
@isVisible bit,
@id_curriculum integer
as
begin
	begin try
		if not exists (
			select 1
			from cvbuilder.Curriculum
			where CurriculumID = @id_curriculum
		)
		begin
			raiserror('El curriculum no existe.',16,1)
			return
		end

		insert into cvbuilder.Certificates (
			Name, Institute, OnlineMode, InProgress, Year, Description, IsVisible, ID_Curriculum
		)
		values (
			@name, @institute, @onlineMode, @inProgress, @year, @description, @isVisible, @id_curriculum
		)
	end try
	begin catch
		declare @ErrorMessage nvarchar(4000)
		declare @ErrorSeverity integer
		declare @ErrorState integer

		select 
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE()

		-- Use RAISERROR inside the CATCH block to return error
		-- information about the original error that caused
		-- execution to jump to the CATCH block.
		raiserror (
			@ErrorMessage, -- Message text.
			@ErrorSeverity, -- Severity.
			@ErrorState -- State.
		)
		return
	end catch
end
go

create procedure usp_Certificates_Update
@id integer,
@name nvarchar(100),
@institute nvarchar(100),
@onlineMode bit,
@inProgress bit,
@year integer,
@description nvarchar(300),
@isVisible bit,
@id_curriculum integer
as
begin
	begin try
		if not exists (
			select 1
			from cvbuilder.Certificates
			where CertificateID = @id
		)
		begin
			raiserror('El ítem indicado dentro de esta sección no existe.',16,1)
			return
		end

		if not exists (
			select 1
			from cvbuilder.Curriculum
			where CurriculumID = @id_curriculum
		)
		begin
			raiserror('El curriculum no existe.',16,1)
			return
		end

		update cvbuilder.Certificates set
			Name = @name,
			Institute = @institute,
			OnlineMode = @onlineMode,
			InProgress = @inProgress,
			Year = @year,
			Description = @description,
			IsVisible = @isVisible,
			ID_Curriculum = @id_curriculum
		where CertificateID = @id
	end try
	begin catch
		declare @ErrorMessage nvarchar(4000)
		declare @ErrorSeverity integer
		declare @ErrorState integer

		select 
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE()

		-- Use RAISERROR inside the CATCH block to return error
		-- information about the original error that caused
		-- execution to jump to the CATCH block.
		raiserror (
			@ErrorMessage, -- Message text.
			@ErrorSeverity, -- Severity.
			@ErrorState -- State.
		)
		return
	end catch
end
go

create procedure usp_Certificates_Delete
@id integer
as
begin
	begin try
		delete from cvbuilder.Certificates
		where CertificateID = @id
	end try
	begin catch
		declare @ErrorMessage nvarchar(4000)
		declare @ErrorSeverity integer
		declare @ErrorState integer

		select 
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE()

		-- Use RAISERROR inside the CATCH block to return error
		-- information about the original error that caused
		-- execution to jump to the CATCH block.
		raiserror (
			@ErrorMessage, -- Message text.
			@ErrorSeverity, -- Severity.
			@ErrorState -- State.
		)
		return
	end catch
end
go

create procedure usp_Languages_Create
@name nvarchar(100),
@level nvarchar(50),
@isVisible bit,
@id_curriculum integer
as
begin
	begin try
		if not exists (
			select 1
			from cvbuilder.Curriculum
			where CurriculumID = @id_curriculum
		)
		begin
			raiserror('El curriculum no existe.',16,1)
			return
		end

		insert into cvbuilder.Languages (
			Name, Level, IsVisible, ID_Curriculum
		)
		values (
			@name, @level, @isVisible, @id_curriculum
		)
	end try
	begin catch
		declare @ErrorMessage nvarchar(4000)
		declare @ErrorSeverity integer
		declare @ErrorState integer

		select 
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE()

		-- Use RAISERROR inside the CATCH block to return error
		-- information about the original error that caused
		-- execution to jump to the CATCH block.
		raiserror (
			@ErrorMessage, -- Message text.
			@ErrorSeverity, -- Severity.
			@ErrorState -- State.
		)
		return
	end catch
end
go

create procedure usp_Languages_Update
@id integer,
@name nvarchar(100),
@level nvarchar(50),
@isVisible bit,
@id_curriculum integer
as
begin
	begin try
		if not exists (
			select 1
			from cvbuilder.Languages
			where LanguageID = @id
		)
		begin
			raiserror('El ítem indicado dentro de esta sección no existe.',16,1)
			return
		end

		if not exists (
			select 1
			from cvbuilder.Curriculum
			where CurriculumID = @id_curriculum
		)
		begin
			raiserror('El curriculum no existe.',16,1)
			return
		end

		update cvbuilder.Languages set
			Name = @name,
			Level = @level,
			IsVisible = @isVisible,
			ID_Curriculum = @id_curriculum
		where LanguageID = @id
	end try
	begin catch
		declare @ErrorMessage nvarchar(4000)
		declare @ErrorSeverity integer
		declare @ErrorState integer

		select 
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE()

		-- Use RAISERROR inside the CATCH block to return error
		-- information about the original error that caused
		-- execution to jump to the CATCH block.
		raiserror (
			@ErrorMessage, -- Message text.
			@ErrorSeverity, -- Severity.
			@ErrorState -- State.
		)
		return
	end catch
end
go

create procedure usp_Languages_Delete
@id integer
as
begin
	begin try
		delete from cvbuilder.Languages
		where LanguageID = @id
	end try
	begin catch
		declare @ErrorMessage nvarchar(4000)
		declare @ErrorSeverity integer
		declare @ErrorState integer

		select 
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE()

		-- Use RAISERROR inside the CATCH block to return error
		-- information about the original error that caused
		-- execution to jump to the CATCH block.
		raiserror (
			@ErrorMessage, -- Message text.
			@ErrorSeverity, -- Severity.
			@ErrorState -- State.
		)
		return
	end catch
end
go

create procedure usp_Skills_Create
@name nvarchar(100),
@level nvarchar(50),
@isVisible bit,
@id_curriculum integer
as
begin
	begin try
		if not exists (
			select 1
			from cvbuilder.Curriculum
			where CurriculumID = @id_curriculum
		)
		begin
			raiserror('El curriculum no existe.',16,1)
			return
		end

		insert into cvbuilder.Skills (
			Name, Level, IsVisible, ID_Curriculum
		)
		values (
			@name, @level, @isVisible, @id_curriculum
		)
	end try
	begin catch
		declare @ErrorMessage nvarchar(4000)
		declare @ErrorSeverity integer
		declare @ErrorState integer

		select 
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE()

		-- Use RAISERROR inside the CATCH block to return error
		-- information about the original error that caused
		-- execution to jump to the CATCH block.
		raiserror (
			@ErrorMessage, -- Message text.
			@ErrorSeverity, -- Severity.
			@ErrorState -- State.
		)
		return
	end catch
end
go

create procedure usp_Skills_Update
@id integer,
@name nvarchar(100),
@level nvarchar(50),
@isVisible bit,
@id_curriculum integer
as
begin
	begin try
		if not exists (
			select 1
			from cvbuilder.Skills
			where SkillID = @id
		)
		begin
			raiserror('El ítem indicado dentro de esta sección no existe.',16,1)
			return
		end

		if not exists (
			select 1
			from cvbuilder.Curriculum
			where CurriculumID = @id_curriculum
		)
		begin
			raiserror('El curriculum no existe.',16,1)
			return
		end

		update cvbuilder.Skills set
			Name = @name,
			Level = @level,
			IsVisible = @isVisible,
			ID_Curriculum = @id_curriculum
		where SkillID = @id
	end try
	begin catch
		declare @ErrorMessage nvarchar(4000)
		declare @ErrorSeverity integer
		declare @ErrorState integer

		select 
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE()

		-- Use RAISERROR inside the CATCH block to return error
		-- information about the original error that caused
		-- execution to jump to the CATCH block.
		raiserror (
			@ErrorMessage, -- Message text.
			@ErrorSeverity, -- Severity.
			@ErrorState -- State.
		)
		return
	end catch
end
go

create procedure usp_Skills_Delete
@id integer
as
begin
	begin try
		delete from cvbuilder.Skills
		where SkillID = @id
	end try
	begin catch
		declare @ErrorMessage nvarchar(4000)
		declare @ErrorSeverity integer
		declare @ErrorState integer

		select 
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE()

		-- Use RAISERROR inside the CATCH block to return error
		-- information about the original error that caused
		-- execution to jump to the CATCH block.
		raiserror (
			@ErrorMessage, -- Message text.
			@ErrorSeverity, -- Severity.
			@ErrorState -- State.
		)
		return
	end catch
end
go

create procedure usp_Interests_Create
@name nvarchar(100),
@isVisible bit,
@id_curriculum integer
as
begin
	begin try
		if not exists (
			select 1
			from cvbuilder.Curriculum
			where CurriculumID = @id_curriculum
		)
		begin
			raiserror('El curriculum no existe.',16,1)
			return
		end

		insert into cvbuilder.Interests (
			Name, IsVisible, ID_Curriculum
		)
		values (
			@name, @isVisible, @id_curriculum
		)
	end try
	begin catch
		declare @ErrorMessage nvarchar(4000)
		declare @ErrorSeverity integer
		declare @ErrorState integer

		select 
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE()

		-- Use RAISERROR inside the CATCH block to return error
		-- information about the original error that caused
		-- execution to jump to the CATCH block.
		raiserror (
			@ErrorMessage, -- Message text.
			@ErrorSeverity, -- Severity.
			@ErrorState -- State.
		)
		return
	end catch
end
go

create procedure usp_Interests_Update
@id integer,
@name nvarchar(100),
@isVisible bit,
@id_curriculum integer
as
begin
	begin try
		if not exists (
			select 1
			from cvbuilder.Interests
			where InterestID = @id
		)
		begin
			raiserror('El ítem indicado dentro de esta sección no existe.',16,1)
			return
		end

		if not exists (
			select 1
			from cvbuilder.Curriculum
			where CurriculumID = @id_curriculum
		)
		begin
			raiserror('El curriculum no existe.',16,1)
			return
		end

		update cvbuilder.Interests set
			Name = @name,
			IsVisible = @isVisible,
			ID_Curriculum = @id_curriculum
		where InterestID = @id
	end try
	begin catch
		declare @ErrorMessage nvarchar(4000)
		declare @ErrorSeverity integer
		declare @ErrorState integer

		select 
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE()

		-- Use RAISERROR inside the CATCH block to return error
		-- information about the original error that caused
		-- execution to jump to the CATCH block.
		raiserror (
			@ErrorMessage, -- Message text.
			@ErrorSeverity, -- Severity.
			@ErrorState -- State.
		)
		return
	end catch
end
go

create procedure usp_Interests_Delete
@id integer
as
begin
	begin try
		delete from cvbuilder.Interests
		where InterestID = @id
	end try
	begin catch
		declare @ErrorMessage nvarchar(4000)
		declare @ErrorSeverity integer
		declare @ErrorState integer

		select 
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE()

		-- Use RAISERROR inside the CATCH block to return error
		-- information about the original error that caused
		-- execution to jump to the CATCH block.
		raiserror (
			@ErrorMessage, -- Message text.
			@ErrorSeverity, -- Severity.
			@ErrorState -- State.
		)
		return
	end catch
end
go

create procedure usp_PersonalReferences_Create
@company nvarchar(100),
@contactPerson nvarchar(200),
@areaCode smallint,
@telephone integer,
@email nvarchar(100),
@isVisible bit,
@id_curriculum integer
as
begin
	begin try
		if not exists (
			select 1
			from cvbuilder.Curriculum
			where CurriculumID = @id_curriculum
		)
		begin
			raiserror('El curriculum no existe.',16,1)
			return
		end

		insert into cvbuilder.PersonalReferences (
			Company, ContactPerson, AreaCode, Telephone, Email, IsVisible, ID_Curriculum
		)
		values (
			@company, @contactPerson, @areaCode, @telephone, @email, @isVisible, @id_curriculum
		)
	end try
	begin catch
		declare @ErrorMessage nvarchar(4000)
		declare @ErrorSeverity integer
		declare @ErrorState integer

		select 
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE()

		-- Use RAISERROR inside the CATCH block to return error
		-- information about the original error that caused
		-- execution to jump to the CATCH block.
		raiserror (
			@ErrorMessage, -- Message text.
			@ErrorSeverity, -- Severity.
			@ErrorState -- State.
		)
		return
	end catch
end
go

create procedure usp_PersonalReferences_Update
@id integer,
@company nvarchar(100),
@contactPerson nvarchar(200),
@areaCode smallint,
@telephone integer,
@email nvarchar(100),
@isVisible bit,
@id_curriculum integer
as
begin
	begin try
		if not exists (
			select 1
			from cvbuilder.PersonalReferences
			where PersonalReferenceID = @id
		)
		begin
			raiserror('El ítem indicado dentro de esta sección no existe.',16,1)
			return
		end

		if not exists (
			select 1
			from cvbuilder.Curriculum
			where CurriculumID = @id_curriculum
		)
		begin
			raiserror('El curriculum no existe.',16,1)
			return
		end

		update cvbuilder.PersonalReferences set
			Company = @company,
			ContactPerson = @contactPerson,
			AreaCode = @areaCode,
			Telephone = @telephone,
			Email = @email,
			IsVisible = @isVisible,
			ID_Curriculum = @id_curriculum
		where PersonalReferenceID = @id
	end try
	begin catch
		declare @ErrorMessage nvarchar(4000)
		declare @ErrorSeverity integer
		declare @ErrorState integer

		select 
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE()

		-- Use RAISERROR inside the CATCH block to return error
		-- information about the original error that caused
		-- execution to jump to the CATCH block.
		raiserror (
			@ErrorMessage, -- Message text.
			@ErrorSeverity, -- Severity.
			@ErrorState -- State.
		)
		return
	end catch
end
go

create procedure usp_PersonalReferences_Delete
@id integer
as
begin
	begin try
		delete from cvbuilder.PersonalReferences
		where PersonalReferenceID = @id
	end try
	begin catch
		declare @ErrorMessage nvarchar(4000)
		declare @ErrorSeverity integer
		declare @ErrorState integer

		select 
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE()

		-- Use RAISERROR inside the CATCH block to return error
		-- information about the original error that caused
		-- execution to jump to the CATCH block.
		raiserror (
			@ErrorMessage, -- Message text.
			@ErrorSeverity, -- Severity.
			@ErrorState -- State.
		)
		return
	end catch
end
go

create procedure usp_CustomSections_Create
@sectionName nvarchar(100),
@description nvarchar(max),
@isVisible bit,
@id_curriculum integer
as
begin
	begin try
		if not exists (
			select 1
			from cvbuilder.Curriculum
			where CurriculumID = @id_curriculum
		)
		begin
			raiserror('El curriculum no existe.',16,1)
			return
		end

		insert into cvbuilder.CustomSections (
			SectionName, Description, IsVisible, ID_Curriculum
		)
		values (
			@sectionName, @description, @isVisible, @id_curriculum
		)
	end try
	begin catch
		declare @ErrorMessage nvarchar(4000)
		declare @ErrorSeverity integer
		declare @ErrorState integer

		select 
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE()

		-- Use RAISERROR inside the CATCH block to return error
		-- information about the original error that caused
		-- execution to jump to the CATCH block.
		raiserror (
			@ErrorMessage, -- Message text.
			@ErrorSeverity, -- Severity.
			@ErrorState -- State.
		)
		return
	end catch
end
go

create procedure usp_CustomSections_Update
@id integer,
@sectionName nvarchar(100),
@description nvarchar(max),
@isVisible bit,
@id_curriculum integer
as
begin
	begin try
		if not exists (
			select 1
			from cvbuilder.CustomSections
			where CustomSectionID = @id
		)
		begin
			raiserror('El ítem indicado dentro de esta sección no existe.',16,1)
			return
		end

		if not exists (
			select 1
			from cvbuilder.Curriculum
			where CurriculumID = @id_curriculum
		)
		begin
			raiserror('El curriculum no existe.',16,1)
			return
		end

		update cvbuilder.CustomSections set
			SectionName = @sectionName,
			Description = @description,
			IsVisible = @isVisible,
			ID_Curriculum = @id_curriculum
		where CustomSectionID = @id
	end try
	begin catch
		declare @ErrorMessage nvarchar(4000)
		declare @ErrorSeverity integer
		declare @ErrorState integer

		select 
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE()

		-- Use RAISERROR inside the CATCH block to return error
		-- information about the original error that caused
		-- execution to jump to the CATCH block.
		raiserror (
			@ErrorMessage, -- Message text.
			@ErrorSeverity, -- Severity.
			@ErrorState -- State.
		)
		return
	end catch
end
go

create procedure usp_CustomSections_Delete
@id integer
as
begin
	begin try
		delete from cvbuilder.CustomSections
		where CustomSectionID = @id
	end try
	begin catch
		declare @ErrorMessage nvarchar(4000)
		declare @ErrorSeverity integer
		declare @ErrorState integer

		select 
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE()

		-- Use RAISERROR inside the CATCH block to return error
		-- information about the original error that caused
		-- execution to jump to the CATCH block.
		raiserror (
			@ErrorMessage, -- Message text.
			@ErrorSeverity, -- Severity.
			@ErrorState -- State.
		)
		return
	end catch
end
go