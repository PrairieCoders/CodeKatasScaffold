using System;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoFakeItEasy;

namespace Katas.Tests
{
	public static class FixtureExtensions
	{
		/// <summary>
		/// Customize the fixture with provided customization using CompositeCustomization.
		/// </summary>
		public static IFixture Customize(this IFixture fixture, params ICustomization[] customizations)
		{
			if (fixture == null)
				throw new ArgumentNullException("fixture");

			return fixture.Customize(new CompositeCustomization(customizations));
		}

		/// <summary>
		/// Customize the fixture with the AutoFakeItEasyCustomization and the provided customizations.
		/// </summary>
		public static IFixture CustomizeWithFakeItEasy(this IFixture fixture, params ICustomization[] customizations)
		{
			if (fixture == null)
				throw new ArgumentNullException("fixture");

			return fixture
				.Customize(new AutoFakeItEasyCustomization())
				.Customize(customizations);
		}
		/// <summary>
		/// Maps a request for an abstract type to a specific concrete type.
		/// </summary>
		/// <typeparam name="TAbstract">The abstract type.</typeparam>
		/// <typeparam name="TConcrete">The concrete type to return when the TAbstract type is requested. TConcrete must be a subtype of TAbstract.</typeparam>
		/// <param name="fixture">The Fixture to use to create the type/</param>
		public static void Map<TAbstract, TConcrete>(this IFixture fixture) where TConcrete : TAbstract
		{
			fixture.Register<TAbstract>(() => fixture.Create<TConcrete>());
		}
	}
}