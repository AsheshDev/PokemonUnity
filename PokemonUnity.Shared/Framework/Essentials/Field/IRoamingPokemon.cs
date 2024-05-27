﻿using System;
using System.Collections;
using System.Collections.Generic;
using PokemonUnity;
using PokemonUnity.Inventory;
using PokemonUnity.Overworld;
using PokemonUnity.UX;
using PokemonEssentials.Interface.PokeBattle;

namespace PokemonEssentials.Interface.Field
{
	/// <summary>
	/// Extension on <see cref="ITempMetadata"/>
	/// </summary>
	public interface ITempMetadataRoaming {
		int nowRoaming				{ get; }
		int roamerIndex				{ get; }
	}

	/// <summary>
	/// Extension on <see cref="IGlobalMetadata"/>
	/// </summary>
	public interface IGlobalMetadataRoaming {
		//ToDo: nullable int array?...
		int[] roamPosition				{ get; set; }
		Queue<int> roamHistory			{ get; set; }
		bool roamedAlready				{ get; set; }
		bool roamEncounter				{ get; }
		/// <summary>
		/// Boolean array representing if pokemon is roaming;
		/// <see cref="Kernal.RoamingSpecies"/> as Index/Key
		/// </summary>
		IList<IPokemon> roamPokemon		{ get; set; }
		/// <summary>
		/// Boolean array representing if pokemon is captured;
		/// <see cref="Kernal.RoamingSpecies"/> as Index/Key
		/// </summary>
		Pokemons[] roamPokemonCaught	{ get; }
	}

	/// <summary>
	/// Extension on <see cref="IGame"/>
	/// </summary>
	public interface IGameRoaming {
		/// <summary>
		/// Resets all roaming Pokemon that were defeated without having been caught.
		/// </summary>
		void ResetAllRoamers();

		/// <summary>
		/// Gets the roaming areas for a particular Pokémon.
		/// </summary>
		IDictionary<int,int[]> RoamingAreas(int index);

		/// <summary>
		/// Puts a roamer in a completely random map available to it.
		/// </summary>
		/// <param name="index"></param>
		void RandomRoam(int index);

		/// <summary>
		/// Roams all roamers, if their Switch is on.
		/// </summary>
		/// <param name="ignoretrail"></param>
		void RoamPokemon(bool ignoretrail = false);

		/// <summary>
		/// Fires whenever the player moves to a new map. Event handler receives the old
		/// map ID or 0 if none.  Also fires when the first map of the game is loaded
		/// </summary>
		event EventHandler OnMapChange;
		//Events.OnMapChange+=proc {|sender,e|

		/// <summary>
		/// Triggers at the start of a wild battle.  Event handlers can provide their own
		/// wild battle routines to override the default behavior.
		/// </summary>
		//event EventHandler<IOnWildBattleOverrideEventArgs> OnWildBattleOverride;
		event Action<object, EventArg.IOnWildBattleOverrideEventArgs> OnWildBattleOverride;
		//Events.OnWildBattleOverride+=proc { |sender,e|

		//PokemonUnity.Combat.BattleResults RoamingPokemonBattle(Pokemons species, int level);
		bool RoamingPokemonBattle(Pokemons species, int level);

		//EncounterModifier.register(proc {|encounter|});
		//void register(Func<IEncounterPokemon, IEncounterPokemon> p);

		//EncounterModifier.registerEncounterEnd(proc {});
		//EncounterModifier.registerEncounterEnd(Action);
		//void registerEncounterEnd(Action p);

		/// <summary>
		/// </summary>
		/// <param name="enctype">
		/// None		= 0,
		/// Any encounter method (except triggered ones and Bug Contest);
		/// Walking		= 1,
		/// Grass (except Bug Contest)/walking in caves only;
		/// Surfing		= 2,
		/// Surfing only;
		/// Fishing		= 3,
		/// Fishing only;
		/// AnyWater	= 4
		/// Water-based only
		/// </param>
		/// <returns></returns>
		bool RoamingMethodAllowed(EncounterTypes enctype);
		//bool RoamingMethodAllowed(Method enctype);
	}
}