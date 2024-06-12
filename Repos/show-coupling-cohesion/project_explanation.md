# Convoy

Convoy consists of maximal two trucks (front and back), waggons and addons.

## Attributes

-   _Speed_ (maximum of speed of trucks)
-   _Power_ (sum of power of trucks)
-   _Keywords_ (composed of all keywords slots)
-   _Price_ (comosed of all Components of convoy)

# Truck

One truck can pull multiple waggons. Every waggon belongs to one truck.

Every truck can have one addon.

## Attributes

-   Code: simple name of truck
-   Speed
-   Price (only from truck)
-   Power: How many waggons can the truck pull.
-   Slots
-   Addon?

# Waggon

Every waggon has some slots and can have one addon. You cannot place unlimited waggons because trucks can only pull a limited amount of waggons.

## Attributes

-   Keywords
-   Price
-   Addon?

# Addon

Add more slots to convoy. One truck / waggon can only carry one addon.

## Attributes

-   Keywords
-   Price
-   Slot

# Slot

Three types of slots:

-   Default: empty or any cargo
-   Predestined: specific usecase
-   Machinery: occupies slot

Three states of slots:

-   active: without restrictions; can get hit
-   damaged: can be repaired or completely destroyed if hit again
-   destroyed: cannot be repaired nor used

## Attributes

-   Keywords: Convoy looses slot keyword if slot destroyed
