/****** Object:  Table [dbo].[CampaignGame]  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PartnerCampaign](
	[ID] [uniqueidentifier] NOT NULL,
	[Partner_ID_FK] [uniqueidentifier] NOT NULL,
	[Campaign_ID_FK] [uniqueidentifier] NOT NULL,
	PRIMARY KEY (ID),
    CONSTRAINT FK_PartnerCampaignCampaign FOREIGN KEY ([Campaign_ID_FK])
    REFERENCES [Campaign](ID),
	CONSTRAINT FK_PartnerCampaignPartner FOREIGN KEY ([Partner_ID_FK])
    REFERENCES [Partner](ID)
)
GO