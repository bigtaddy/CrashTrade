class AddAtributesToProfiles < ActiveRecord::Migration
  def self.up
    add_column :profiles, :name, :string 
    add_column :profiles, :city, :string 
    add_column :profiles, :language, :string     
    add_column :profiles, :about, :string 
  end
  def self.down
    remove_column :profiles, :name      
    remove_column :profiles, :city
    remove_column :profiles, :language
    remove_column :profiles, :about
  end

end
