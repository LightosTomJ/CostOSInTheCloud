CREATE TABLE [dbo].[alcUserSettings] (
    [UserId]    UNIQUEIDENTIFIER NOT NULL,
    [SettingId] UNIQUEIDENTIFIER NOT NULL,
    [Value]     VARBINARY (MAX)  NULL,
    CONSTRAINT [alcUserSettings_I00] PRIMARY KEY CLUSTERED ([UserId] ASC, [SettingId] ASC)
);

